using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class OrderLine : BaseEntity
	{
		public long OrderId { get; set; }
		public long ProductId { get; set; }
		public long SKU { get; set; }
		public string Title { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }

		public long ShipFromWarehouseId { get; set; }
	}
}
