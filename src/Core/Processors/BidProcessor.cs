using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class BidProcessor
	{
		public async Task<IEnumerable<Bid>> GetBids(long listingId)
		{
			return new List<Bid>();
		}
	}
}
