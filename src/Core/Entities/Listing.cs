using Core.Enums;
using Core.Processors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
	public class Listing : BaseEntity
	{
		public long OwnerId { get; set; }
		public long StoreId { get; set; }

		public string Title { get; set; }
		public string Description { get; set; }

		public bool IsEnabled { get; set; }

		public int ListingType { get; set; }

		public Currencies Currency { get; set; }
		public decimal? RegularPrice { get; set; }
		public decimal? Price { get; set; }
		public decimal? StartPrice { get; set; }
		public decimal? ReservePrice { get; set; }

		public long? Promotion { get; set; }

		//ListingLine!!!

		/// <summary>
		/// Get Store
		/// </summary>
		private Lazy<Task<IEnumerable<StoreSummary>>> _stores;
		public Task<IEnumerable<StoreSummary>> Stores { get { return _stores.Value; } }

		/// <summary>
		/// Get Bids
		/// </summary>
		private Lazy<Task<IEnumerable<Bid>>> _bids;
		public Task<IEnumerable<Bid>> Bids { get { return _bids.Value; } }

		public Listing()
		{
			_stores = new Lazy<Task<IEnumerable<StoreSummary>>>(async () =>
			{
				return await new StoreProcessor().GetUserStores(Id);
			});

			_bids = new Lazy<Task<IEnumerable<Bid>>>(async () =>
			{
				return await new BidProcessor().GetBids(Id);
			});
		}
	}
}
