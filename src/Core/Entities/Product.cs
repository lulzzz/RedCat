using Core.Processors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Product : BaseEntity
	{
		public int? Barcode { get; set; }

		public long OwnerId { get; set; }
		public long CatalogId { get; set; }
		public string SKU { get; set; }
		public bool IsEnabled { get; set; }

		public int ProductType { get; set; }
		public string DownloadLink { get; set; }

		public string Manufacturer { get; set; }
		public string Brand { get; set; }
		public string Collection { get; set; }
		public string Model { get; set; }
		public string MPN { get; set; }
		public string CountryOfOrigin { get; set; }

		public string Name { get; set; }
		public string Description { get; set; }
		public List<string> Images { get; set; } = new List<string>();

		public string Specification { get; set; }
		public Dictionary<string, string> Identifiers { get; set; } = new Dictionary<string, string>();

		public long? WarrantyId { get; set; }
		public long? ReturnId { get; set; }

		public float? Weight { get; set; }
		public float? Width { get; set; }
		public float? Height { get; set; }
		public float? Depth { get; set; }

		public Dictionary<string, IEnumerable<string>> Selectors { get; set; }

		#region Navigations 
		/// <summary>
		/// Get Product inventory on the all warehouses
		/// </summary>
		private Lazy<Task<IEnumerable<Inventory>>> _inventory;
		public Task<IEnumerable<Inventory>> Inventory { get { return _inventory.Value; } }

		/// <summary>
		/// Get all stores where Product is listed
		/// </summary>
		private Lazy<Task<IEnumerable<Store>>> _productInStores;
		public Task<IEnumerable<Store>> ProductInStores { get { return _productInStores.Value; } }

		/// <summary>
		/// Get all orders with a current product
		/// </summary>
		private Lazy<Task<IEnumerable<OrderSummary>>> _productInOrders;
		public Task<IEnumerable<OrderSummary>> ProductInOrders { get { return _productInOrders.Value; } }

		/// <summary>
		/// Get product on warehouse
		/// </summary>
		private Lazy<Task<IEnumerable<ProductInWarehouse>>> _productInWarehouse;
		public Task<IEnumerable<ProductInWarehouse>> ProductInWarehouse { get { return _productInWarehouse.Value; } }

		/// <summary>
		/// Get product reviews
		/// </summary>
		private Lazy<Task<IEnumerable<Review>>> _productReviews;
		public Task<IEnumerable<Review>> ProductReviews { get { return _productReviews.Value; } }

		/// <summary>
		/// Get product rating
		/// </summary>
		private Lazy<Task<RatingSummary>> _productRating;
		public Task<RatingSummary> ProductRating { get { return _productRating.Value; } }

		public Product()
		{
			_inventory = new Lazy<Task<IEnumerable<Inventory>>>(async () =>
			{
				return await new InventoryProcessor().GetInventory(Id);
			});

			_productInStores = new Lazy<Task<IEnumerable<Store>>>(async () =>
			{
				return await new StoreProcessor().GetStoresWithProduct(Id);
			});

			_productInOrders = new Lazy<Task<IEnumerable<OrderSummary>>>(async () =>
			{
				return await new OrderProcessor().GetProductInOrders(Id);
			});

			_productInWarehouse = new Lazy<Task<IEnumerable<ProductInWarehouse>>>(async () =>
			{
				return await new WarehouseProcessor().GetProductInWarehouse(Id);
			});

			_productReviews = new Lazy<Task<IEnumerable<Review>>>(async () =>
			{
				return await new ReviewProcessor().GetProductReviews(Id);
			});

			_productRating = new Lazy<Task<RatingSummary>>(async () =>
			{
				return await new RatingProcessor().GetSummary(Id);
			});
		}
		#endregion
	}
}
