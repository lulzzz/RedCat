using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class HistoryLine : BaseEntity
	{
		public long OrderId { get; set; }
		public long CustomerId { get; set; }
		public int OrderStatus { get; set; }
		public string Comment { get; set; }
		public bool NotifyBuyer { get; set; }
	}
}
