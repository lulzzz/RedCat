using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Database;
using Infrastructure.Database.Migrations.Migrator;
using Grains.Providers.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Extensions.Logging;
using NLog.Web;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Versions.Compatibility;
using Orleans.Versions.Selector;
using Silo.Configuration;

namespace Silo
{
	class Program
	{
		private static async Task<int> Main(string[] args)
		{
			string environmentName = Environment.GetEnvironmentVariable("SERVER_ENVIRONMENT");
			Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", true, true)
				.AddJsonFile($"appsettings.{environmentName}.json", true)
				.AddEnvironmentVariables()
				.Build();

			AppConfig config = new AppConfig();
			configuration.Bind("AppConfig", config);

			try
			{
				if (config.MigrateDatabases)
				{
					EvolveMigrator migrator = new EvolveMigrator();
					migrator.Migrate(config.ConnectionStrings[Constants.System], Constants.SystemScripts, false);
				}

				logger.Info("Rialto Silo has been started");
				ISiloHost host = await StartSilo(config);

				Console.WriteLine("Enter 'exit' to stop...");

				while (!(Console.ReadLine() ?? string.Empty).Equals("exit"))
				{
				}

				await host.StopAsync();
				logger.Info("Rialto Silo has been stopped");
				return 0;
			}
			catch (Exception ex)
			{
				logger.Error(ex, "Rialto Silo is failed");
			}
			finally
			{
				LogManager.Shutdown();
			}

			return -1;
		}

		private static async Task<ISiloHost> StartSilo(AppConfig configuration)
		{
			ISiloHostBuilder builder = new SiloHostBuilder()
				.ConfigureAppConfiguration(config =>
				{
				})
				.Configure<ClusterOptions>(options =>
				{
					options.ClusterId = "InvestorApp";
					options.ServiceId = "Backend";
				})
				.UseAdoNetClustering(options =>
				{
					options.Invariant = "Npgsql";
					options.ConnectionString = configuration.ConnectionStrings[Constants.System];
				})
				.Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
				.ConfigureLogging(logging => logging.AddNLog(new NLogProviderOptions
				{
					CaptureMessageTemplates = true,
					CaptureMessageProperties = true
				}))
				.ConfigureServices(services =>
				{
					services.AddSingleton<AppConfig>(configuration);
				})
				.AddGenericGrainStorage<AssetStorageProvider>(nameof(AssetStorageProvider), opt =>
				{
					opt.Configure(options => { options.ConnectionString = configuration.ConnectionStrings[Constants.Billing]; });
				})
				.Configure<GrainVersioningOptions>(options =>
				{
					options.DefaultCompatibilityStrategy = nameof(BackwardCompatible);
					options.DefaultVersionSelectorStrategy = nameof(MinimumVersion);
				})
				.ConfigureApplicationParts(parts => parts.AddFromApplicationBaseDirectory().WithReferences())
				.UseDashboard(options =>
				{
					//options.Username = "USERNAME";
					//options.Password = "PASSWORD";
					options.Host = "*";
					options.Port = 3128;
					options.HostSelf = true;
					options.CounterUpdateIntervalMs = 5000;
				});

			ISiloHost host = builder.Build();
			await host.StartAsync();
			return host;
		}

	}
}
