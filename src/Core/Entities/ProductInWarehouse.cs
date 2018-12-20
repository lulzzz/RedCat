using Core.Enums;

namespace Core.Entities
{
	public class ProductInWarehouse
	{
		public long WarehouseId { get; set; }
		public long ProductId { get; set; }

		public string SKU { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public Currencies Currency { get; set; }
	}
}
