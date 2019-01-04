using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class Store
	{
		public string Name { get; set; }
		public string Logo { get; set; }
		public string Description { get; set; }
		public string Phone { get; set; }

		public bool IsDisabled { get; set; }
	}
}


//public Customer Owner;
//public IEnumerable<Invoice> Invoices;
//public IEnumerable<Listing> Listings;
//public IEnumerable<Payment> Payments;
//public IEnumerable<Shipping> Shippings;

//public IEnumerable<Rating> Ratings;
