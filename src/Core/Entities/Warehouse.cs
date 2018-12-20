using Core.Processors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Warehouse : BaseEntity
	{
		public bool IsEnabled { get; set; } = true;

		public string Name { get; set; }

		public string Description { get; set; }

		public int ProcessingTime { get; set; }

		public Address Address { get; set; }

		private IEnumerable<long> _warehouseIds { get; set; }

		#region Navigations
		// Products in warehouse
		private Lazy<Task<IEnumerable<ProductInWarehouse>>> _productInWarehouse;
		public Task<IEnumerable<ProductInWarehouse>> ProductInWarehouse { get { return _productInWarehouse.Value; } }

		// Contacts
		private Lazy<Task<IEnumerable<Contact>>> _contacts;
		public Task<IEnumerable<Contact>> Contacts { get { return _contacts.Value; } }

		public Warehouse()
		{
			_productInWarehouse = new Lazy<Task<IEnumerable<ProductInWarehouse>>>(async () =>
			{
				return await new InventoryProcessor().GetWarehouseInventory(Id);
			});

			_contacts = new Lazy<Task<IEnumerable<Contact>>>(async () =>
			{
				return await new ContactProcessor().Get(_warehouseIds);
			});
		}
		#endregion
	}
}
