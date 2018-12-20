using Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
	public class Address : BaseEntity
	{
		public string Company { get; set; }

		public Countries Country { get; set; }

		public string Region { get; set; }

		public string City { get; set; }

		public string Street { get; set; }

		public string Zip { get; set; }
	}
}
