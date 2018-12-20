using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class InventoryProcessor
	{
		public async Task<IEnumerable<Inventory>> Get(long productId)
		{
			return new List<Inventory>()
			{
				new Inventory()
				{
					Comment = "New inv"
				}
			};
		}

		public async Task<IEnumerable<ProductInWarehouse>> GetWarehouseInventory(long warehouseId)
		{

		}
	}
}
