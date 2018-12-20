using Orleans;

namespace Grains.Providers.Storage
{
	public class GenericStorageOptions
	{
		[Redact] public string ConnectionString { get; set; }
	}
}
