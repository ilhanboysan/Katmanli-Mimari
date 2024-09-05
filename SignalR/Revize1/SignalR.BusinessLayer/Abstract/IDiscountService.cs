using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IDiscountService:IGenericSevice<Discount>
    {
		void TChangeStatusToTrue(int id);
		void TChangeStatusToFalse(int id);
		List<Discount> TGetListByStatusTrue();
	}
}
