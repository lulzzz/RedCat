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

		public Customer()
		{
			_stores = new Lazy<Task<IEnumerable<StoreSummary>>>(async () =>
			{
				return await new StoreProcessor().GetUserStores(Id);
			});
		}
	}
}

public Account Account;
public Address Address { get; set; }

public IEnumerable<Order> Orders { get; set; 


public IEnumerable<Review> Reviews { get; set; }

