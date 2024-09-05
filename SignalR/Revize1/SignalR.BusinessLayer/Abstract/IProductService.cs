using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IProductService:IGenericSevice<Product>
    {
        List<Product> TGetProductsWithCategories();
        int TProductCount();
		int TProductCountByCategoryNameHamburger();
		int TProductCountByCategoryNameDrink();
		decimal TProductPriceAvg();
		string TProductNamePriceMax();
		string TProductNamePriceMin();
		decimal TProductAvgPriceByHamburger();
		decimal TProductPriceBySteakBurger();
		decimal TTotalPriceByDrinkCategory();
		decimal TTotalPriceBySaladCategory();
	}
}
