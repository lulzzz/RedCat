using Core.Processors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Customer : BaseEntity
	{
		public bool IsBusiness { get; set; }
		public string CompanyName { get; set; }
		public string Nickname { get; set; }
		public string FirstName { get; set; }
		public string Patronymic { get; set; }
		public string LastName { get; set; }

		public string Email { get; set; }
		public string Phone { get; set; }

		public long AccountId { get; set; }
		public long AddressId { get; set; }

		/// <summary>
		/// Get billing address
		/// </summary>
		private Lazy<Task<IEnumerable<StoreSummary>>> _stores;
		public Task<IEnumerable<StoreSummary>> Stores { get { return _stores.Value; } }

		/// <summary>
		/// Get billing address
		/// </summary>
		private Lazy<Task<IEnumerable<Review>>> _reviews;
		public Task<IEnumerable<Review>> Reviews { get { return _reviews.Value; } }

		/// <summary>
		/// Get Account
		/// </summary>
		private Lazy<Task<Account>> _account;
		public Task<Account> Account { get { return _account.Value; } }

		/// <summary>
		/// Get Address
		/// </summary>
		private Lazy<Task<Address>> _address;
		public Task<Address> BillingAddress { get { return _address.Value; } }

		public Customer()
		{
			_stores = new Lazy<Task<IEnumerable<StoreSummary>>>(async () =>
			{
				return await new StoreProcessor().GetUserStores(Id);
			});

			_reviews = new Lazy<Task<IEnumerable<Review>>>(async () =>
			{
				return await new ReviewProcessor().GetCustomerReviews(Id);
			});

			_account = new Lazy<Task<Account>>(async () =>
			{
				return await new AccountProcessor().GetAccount(AccountId);
			});

			_address = new Lazy<Task<Address>>(async () =>
			{
				return await new AddressProcessor().GetAddress(AddressId);
			});
		}
	}
}
