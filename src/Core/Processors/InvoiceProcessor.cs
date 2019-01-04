using Core.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class InvoiceProcessor
	{
		public async Task<IEnumerable<Invoice>> GetCustomerInvoices(long customerId)
		{
			return new List<Invoice>();

		}
	}
}
