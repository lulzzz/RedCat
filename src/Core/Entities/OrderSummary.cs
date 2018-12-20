using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class OrderSummary
	{
		public long OrderId { get; set; }
		public long BuyerId { get; set; }
		public long StoreId { get; set; }
		public long ProductId { get; set; }

		public DateTime Created { get; set; }
		public string OrderNumber { get; set; }
		public string BuyerName { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
