using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class StoreSummary
	{
		public long Id { get; set; }
		public long CustomerId { get; set; }
		public DateTime Created { get; set; }
		public string Name { get; set; }
		public bool IsDisabled { get; set; }
	}
}
