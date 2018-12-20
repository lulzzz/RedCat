using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;
using Orleans.Storage;

namespace Grains.Providers.Storage
{
	public class AssetStorageProvider : IStorageProvider
	{
		//private AssetsProcessor assetProcessor;
		private string connectionString;

		public AssetStorageProvider(string connectionString)
		{
			this.connectionString = connectionString;
		}

		public Task ReadStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
		{
			//assetProcessor.Get();
			return Task.CompletedTask;
		}

		public Task WriteStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
		{
			throw new NotImplementedException();
		}

		public Task ClearStateAsync(string grainType, GrainReference grainReference, IGrainState grainState)
		{
			string key = grainReference.GetPrimaryKeyString();

			return Task.CompletedTask;
		}

		public Task Init(string name, IProviderRuntime providerRuntime, IProviderConfiguration config)
		{
			Name = name;
			return Task.CompletedTask;
		}

		public Task Close()
		{
			return Task.CompletedTask;
		}

		public string Name { get; set; }
	}
}
