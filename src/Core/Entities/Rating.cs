using Core.Processors;
using Grains.Processors;
using System;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Rating : BaseEntity
	{
		public long ProductId { get; set; }
		public long CustomerId { get; set; }
		public long StoreId { get; set; }

		public int ProductRating { get; set; }
		public int DescriptionRating { get; set; }
		public int ShippingRating { get; set; }
		public int CommunicationRating { get; set; }
		public string Comment { get; set; }

		/// <summary>
		/// Get warehouse
		/// </summary>
		private Lazy<Task<Product>> _product;
		public Task<Product> Product { get { return _product.Value; } }

		/// <summary>
		/// Get Buyer
		/// </summary>
		private Lazy<Task<Customer>> _buyer;
		public Task<Customer> Buyer { get { return _buyer.Value; } }

		/// <summary>
		/// Get Store
		/// </summary>
		private Lazy<Task<Store>> _store;
		public Task<Store> Store { get { return _store.Value; } }

		public Rating()
		{
			_product = new Lazy<Task<Product>>(async () =>
			{
				return await new ProductProcessor().GetProduct(ProductId);
			});

			_buyer = new Lazy<Task<Customer>>(async () =>
			{
				return await new CustomerProcessor().GetCustomer(CustomerId);
			});

			_store = new Lazy<Task<Store>>(async () =>
			{
				return await new StoreProcessor().GetStore(StoreId);
			});
		}
	}
}
