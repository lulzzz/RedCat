using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class RatingSummary
	{
		public long ProductId { get; set; }
		public int FiveStars { get; set; }
		public int FourStars { get; set; }
		public int ThreeStars { get; set; }
		public int TwoStars { get; set; }
		public int OneStars { get; set; }
	}
}
