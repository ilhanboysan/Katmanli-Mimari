using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
	public class OrderDetailsManager : IOrderDetailsService
	{
		private readonly IOrderDetailsDal _orderDetailsDal;

		public OrderDetailsManager(IOrderDetailsDal orderDetailsDal)
		{
			_orderDetailsDal = orderDetailsDal;
		}

		public void TAdd(OrderDetails entity)
		{
			throw new NotImplementedException();
		}

		public void TDelete(OrderDetails entity)
		{
			throw new NotImplementedException();
		}

		public OrderDetails TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<OrderDetails> TGetListAll()
		{
			throw new NotImplementedException();
		}

		public void TUpdate(OrderDetails entity)
		{
			throw new NotImplementedException();
		}
	}
}
