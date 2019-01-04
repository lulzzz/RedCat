using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class TransactionProcessor
	{
		public async Task<IEnumerable<Transaction>> GetAccountTransaction(long accountId)
		{
			return new List<Transaction>();
		}

		public async Task<IEnumerable<Transaction>> GetInvoiceTransaction(long invoiceId)
		{
			return new List<Transaction>();
		}
	}
}
