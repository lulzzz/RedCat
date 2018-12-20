using Core.Enums;
using Core.Processors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Order : BaseEntity
	{
		public long ListingId { get; set; }
		public long StoreId { get; set; }
		public long? InvoiceId { get; set; }

		public int? Barcode { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public DateTime? DateReceived { get; set; }

		public int OrderStatus { get; set; }
		public string StatusDescription { get; set; }
		public string OrderNumber { get; set; }

		public string Buyer { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }

		public Currencies Currency { get; set; }
		public decimal TotalAmount { get; set; }
		public decimal Shipping { get; set; }
		public decimal Tax { get; set; }
		public decimal Discount { get; set; }
		public string DiscountCardOrCode { get; set; }

		public long ShippingAddressId { get; set; }
		public long BillingAddressId { get; set; }

		public string ShippingMetho { get; set; }
		public string PaymentMethod { get; set; }

		#region Navigations 
		/// <summary>
		/// Get Order Lines
		/// </summary>
		private Lazy<Task<IEnumerable<OrderLine>>> _orderLines;
		public Task<IEnumerable<OrderLine>> OrderLines { get { return _orderLines.Value; } }

		/// <summary>
		/// Get History Lines
		/// </summary>
		private Lazy<Task<IEnumerable<HistoryLine>>> _historyLines;
		public Task<IEnumerable<HistoryLine>> HistoryLines { get { return _historyLines.Value; } }

		/// <summary>
		/// Get shipments
		/// </summary>
		private Lazy<Task<IEnumerable<Shipment>>> _shipments;
		public Task<IEnumerable<Shipment>> Shipments { get { return _shipments.Value; } }

		/// <summary>
		/// Get shipping address
		/// </summary>
		private Lazy<Task<Address>> _shippingAddress;
		public Task<Address> ShippingAddress { get { return _shippingAddress.Value; } }

		/// <summary>
		/// Get billing address
		/// </summary>
		private Lazy<Task<Address>> _billingAddress;
		public Task<Address> BillingAddress { get { return _billingAddress.Value; } }

		public Order()
		{
			_orderLines = new Lazy<Task<IEnumerable<OrderLine>>>(async () =>
			{
				return await new OrderProcessor().GetOrderLines(Id);
			});

			_historyLines = new Lazy<Task<IEnumerable<HistoryLine>>>(async () =>
			{
				return await new OrderProcessor().GetHistoryLines(Id);
			});

			_shipments = new Lazy<Task<IEnumerable<Shipment>>>(async () =>
			{
				return await new OrderProcessor().GetOrderShipments(Id);
			});

			_shippingAddress = new Lazy<Task<Address>>(async () =>
			{
				return await new AddressProcessor().GetAddress(ShippingAddressId);
			});

			_billingAddress = new Lazy<Task<Address>>(async () =>
			{
				return await new AddressProcessor().GetAddress(BillingAddressId);
			});
		}
		#endregion
	}
}
