using Core.Processors;
using System;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Inventory : BaseEntity
	{
		public long ProductId { get; set; }
		public long? WarehouseId { get; set; }
		public int ShippingDays { get; set; }
		public int Availability { get; set; }

		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public string Comment { get; set; }

		/// <summary>
		/// Get warehouse
		/// </summary>
		private Lazy<Task<Warehouse>> _warehouse;
		public Task<Warehouse> Warehouse { get { return WarehouseId.HasValue ? _warehouse.Value : null; } }

		public Inventory()
		{
			_warehouse = new Lazy<Task<Warehouse>>(async () =>
			{
				return await new WarehouseProcessor().Get(Id);
			});
		}
	}
}
