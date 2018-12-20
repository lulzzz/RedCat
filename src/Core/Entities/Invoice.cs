using Core.Processors;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Invoice : BaseEntity
	{
		public string Number { get; set; }

		public long OrderId { get; set; }
		public long StoreId { get; set; }
		public long CustomerId { get; set; }

		/// <summary>
		/// Get Customer
		/// </summary>
		private Lazy<Task<Customer>> _customer;
		public Task<Customer> Customer { get { return _customer.Value; } }

		/// <summary>
		/// Get Store
		/// </summary>
		private Lazy<Task<Store>> _store;
		public Task<Store> Store { get { return _store.Value; } }

		/// <summary>
		/// Get Invoiced Order
		/// </summary>
		private Lazy<Task<Order>> _order;
		public Task<Order> Order { get { return _order.Value; } }

		/// <summary>
		/// Get Invoice Transaction
		/// </summary>
		private Lazy<Task<IEnumerable<Transaction>>> _transactions;
		public Task<IEnumerable<Transaction>> Transactions { get { return _transactions.Value; } }

		public Invoice()
		{
			_customer = new Lazy<Task<Customer>>(async () =>
			{
				return await new CustomerProcessor().GetCustomer(CustomerId);
			});

			_store = new Lazy<Task<Store>>(async () =>
			{
				return await new StoreProcessor().GetStore(StoreId);
			});

			_order = new Lazy<Task<Order>>(async () =>
			{
				return await new OrderProcessor().GetOrder(Id);
			});

			_transactions = new Lazy<Task<IEnumerable<Transaction>>>(async () =>
			{
				return await new TransactionProcessor().GetInvoiceTransaction(Id);
			});
		}
	}
}
