using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class Bid : BaseEntity
	{
		public bool IsDeclined { get; set; }
		public string DeclineReason { get; set; }

		public long CustomerId { get; set; }
		public long ListingId { get; set; }

		public decimal Amount { get; set; }
	}
}
