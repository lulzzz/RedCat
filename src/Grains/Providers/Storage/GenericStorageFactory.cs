using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Orleans.Storage;

namespace Grains.Providers.Storage
{
	internal class GenericStorageFactory
	{
		public static IGrainStorage Create<T>(IServiceProvider services, string name) where T : IGrainStorage
		{
			IOptionsSnapshot<GenericStorageOptions> optionsSnapshot = services.GetRequiredService<IOptionsSnapshot<GenericStorageOptions>>();
			GenericStorageOptions options = optionsSnapshot.Get(name);;
			object[] args = new object[] { options.ConnectionString ?? String.Empty };
			return ActivatorUtilities.CreateInstance<T>(services, args);
		}
	}
}
