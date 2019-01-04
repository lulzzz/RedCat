using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class ReviewProcessor
	{
		public async Task<IEnumerable<Review>> GetProductReviews(long productId)
		{
			return new List<Review>();
		}

		public async Task<IEnumerable<Review>> GetCustomerReviews(long customerId)
		{
			return new List<Review>();
		}
	}
}
