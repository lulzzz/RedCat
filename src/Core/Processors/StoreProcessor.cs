using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class StoreProcessor
	{
		public async Task<Store> GetStore(long storeId)
		{
			return new Store();
		}

		public async Task<IEnumerable<Store>> GetStoresWithProduct(long productId)
		{
			return new List<Store>();
		}

		public async Task<IEnumerable<StoreSummary>> GetUserStores(long userId)
		{
			return new List<StoreSummary>();
		}
	}
}
