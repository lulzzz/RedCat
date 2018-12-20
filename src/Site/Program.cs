using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Web;

namespace Site
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Logger logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

			try
			{
				CreateWebHostBuilder(args).Build().Run();
				logger.Info("Application is started");
			}
			catch (Exception ex)
			{
				logger.Fatal(ex, "Stopped program because of exception");
				throw;
			}
			finally
			{
				NLog.LogManager.Shutdown();
			}
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseNLog();
	}
}
