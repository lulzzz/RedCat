﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class WarehouseProcessor
	{
		public async Task<Warehouse> Get(long id)
		{
			return new Warehouse();
		}

		public async Task<IEnumerable<ProductInWarehouse>> GetProductInWarehouse(long productId)
		{
			return new List<ProductInWarehouse>();
		}
	}
}
