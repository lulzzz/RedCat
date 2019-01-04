

using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;

namespace Site.Core
{
	/// <summary>
	/// Orleans cluster client
	/// </summary>
	public class OrleansConnector
	{
		private string connectionString;
		private IClusterClient client { get; set; } = null;
		ILogger<OrleansConnector> logger;

		public IClusterClient Client
		{
			get
			{
				if (client == null || !client.IsInitialized)
				{
					try
					{
						client = Connect().Result;
					}
					catch(Exception ex)
					{
						// Log and ignore
						logger.LogError("Can't connect to Orleans cluster", ex);
					}
				}

				return client;
			}
		}

		public OrleansConnector(IConfiguration configuration, ILogger<OrleansConnector> logger)
		{
			this.connectionString = configuration.GetConnectionString("SystemConnection");
			this.logger = logger;
		}

		/// <summary>
		/// Create and configure Orleans client
		/// </summary>
		public async Task<IClusterClient> Connect()
		{
			int attempt = 0;
			IClusterClient client = null;
			while (true)
			{
				try
				{
					client = new ClientBuilder()
						.UseAdoNetClustering(options =>
						{
							options.Invariant = "Npgsql";
							options.ConnectionString = this.connectionString;
						}).Configure<ClusterOptions>(options =>
						{
							options.ClusterId = "InvestorApp";
							options.ServiceId = "Backend";
						})
						.Build();

					await client.Connect();
					logger.LogInformation("Client successfully connect to silo host");
					break;
				}
				catch (SiloUnavailableException ex)
				{
					attempt++;
					// TODO: Move max attmpts count to config
					if (attempt > 5)
					{
						throw;
					}
					await Task.Delay(TimeSpan.FromSeconds(4));
				}
			}

			return client;
		}
	}
}
