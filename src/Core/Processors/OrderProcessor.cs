using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Processors
{
	public class OrderProcessor
	{
		public async Task<IEnumerable<OrderSummary>> GetProductInOrders(long orderId)
		{

		}

		public async Task<Order> GetOrder(long orderId)
		{

		}


		public async Task<IEnumerable<OrderLine>> GetOrderLines(long orderId)
		{

		}

		public async Task<IEnumerable<HistoryLine>> GetHistoryLines(long orderId)
		{

		}

		public async Task<IEnumerable<Shipment>> GetOrderShipments(long orderId)
		{

		}
	}
}
