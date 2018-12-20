using System;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;
using Orleans.Storage;

namespace Grains.Providers.Storage
{
	public static class AddGenericStorageProvider
	{
		public static ISiloHostBuilder AddGenericGrainStorage<T>(this ISiloHostBuilder builder, string name, Action<OptionsBuilder<GenericStorageOptions>> options = null) where T : IGrainStorage
		{
			return builder.ConfigureServices(services =>
			{
				options?.Invoke(services.AddOptions<GenericStorageOptions>(name));
				services.ConfigureNamedOptionForLogging<GenericStorageOptions>(name);
				services.TryAddSingleton<IGrainStorage>(sp => sp.GetServiceByName<IGrainStorage>(nameof(T)));
				services.AddSingletonNamedService<IGrainStorage>(name, GenericStorageFactory.Create<T>);
			});
		}
	}
}
