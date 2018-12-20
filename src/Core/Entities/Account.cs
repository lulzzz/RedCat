using Core.Processors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Account : BaseEntity
	{
		public long CustomerId { get; set; }



		/// <summary>
		/// Get Customer
		/// </summary>
		private Lazy<Task<Customer>> _customer;
		public Task<Customer> Customer { get { return _customer.Value; } }

		/// <summary>
		/// Get Invoices
		/// </summary>
		private Lazy<Task<IEnumerable<Invoice>>> _invoices;
		public Task<IEnumerable<Invoice>> Invoices { get { return _invoices.Value; } }

		/// <summary>
		/// Get Transactions
		/// </summary>
		private Lazy<Task<IEnumerable<Transaction>>> _transactions;
		public Task<IEnumerable<Transaction>> Transactions { get { return _transactions.Value; } }

		public Account()
		{
			_customer = new Lazy<Task<Customer>>(async () =>
			{
				return await new CustomerProcessor().GetCustomer(CustomerId);
			});

			_invoices = new Lazy<Task<IEnumerable<Invoice>>>(async () =>
			{
				return await new InvoiceProcessor().GetCustomerInvoices(CustomerId);
			});

			_transactions = new Lazy<Task<IEnumerable<Transaction>>>(async () =>
			{
				return await new TransactionProcessor().GetAccountTransaction(Id);
			});
		}
	}
}
