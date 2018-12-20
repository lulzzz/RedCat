using System.Collections.Generic;

namespace Silo.Configuration
{
	public class AppConfig
	{
		public bool MigrateDatabases { get; set; }
		public IDictionary<string, string> ConnectionStrings { get; set; }

		public bool UseEncrypted { get; set; }
	}
}
