using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class ContactProcessor
	{
		public async Task<IEnumerable<Contact>> Get(IEnumerable<long> ids)
		{
			return new List<Contact>();
		}
	}
}
