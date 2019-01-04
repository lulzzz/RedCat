using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class AccountProcessor
	{
		public async Task<Account> GetAccount(long accountId)
		{
			return new Account();
		}
	}
}
