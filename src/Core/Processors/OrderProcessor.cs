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
			return new List<OrderSummary>();
		}

		public async Task<Order> GetOrder(long orderId)
		{
			return new Order();
		}


		public async Task<IEnumerable<OrderLine>> GetOrderLines(long orderId)
		{
			return new List<OrderLine>();
		}

		public async Task<IEnumerable<HistoryLine>> GetHistoryLines(long orderId)
		{
			return new List<HistoryLine>();
		}

		public async Task<IEnumerable<Shipment>> GetOrderShipments(long orderId)
		{
			return new List<Shipment>();
		}
	}
}
