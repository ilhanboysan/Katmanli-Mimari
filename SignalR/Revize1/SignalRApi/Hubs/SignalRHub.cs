using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using System.Configuration;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingSevice _bookingSevice ;
		private readonly INotificationService _notificationService ;

        private static int clientCount = 0;
        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingSevice bookingSevice, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingSevice = bookingSevice;
			_notificationService = notificationService;
		}

        public async Task SendStatistic()
		{
			var value = _categoryService.TCategoryCount();
			await Clients.All.SendAsync("ReceiveCategoryCount",value);

			var value2 = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", value2);

			var value3 = _categoryService.TActiveCategoryCount();
			await Clients.All.SendAsync("ActiveCategoryCount", value3);

			var value4 = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("PassiveCategoryCount", value4);

			var value5=_productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ProductCountByCategoryNameHamburger", value5);

			var value6 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ProductCountByCategoryNameDrink", value6);

			var value7 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ProductPriceAvg", value7.ToString("0.00") + "₺");

			var value8 = _productService.TProductNamePriceMax();
			await Clients.All.SendAsync("ProductNamePriceMax", value8);

			var value9 = _productService.TProductNamePriceMin();
			await Clients.All.SendAsync("ProductNamePriceMin", value9);

			var value10 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

			var value11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("TotalOrderCount", value11);

			var value12 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ActiveOrderCount", value12);

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("LastOrderPrice", value13.ToString("0.00") + "₺");

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("TotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

			var value16 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("MenuTableCount", value16);


		}

		public async Task SendProgress()
		{
			var value = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("TotalMoneyCaseAmount", value.ToString("0.00") + "₺");

			var value2 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ActiveOrderCount", value2);

			var value3 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("MenuTableCount", value3);

			var value5 = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriveAvg", value5);

			var value6 = _productService.TProductAvgPriceByHamburger();
			await Clients.All.SendAsync("ReceiveAvgPriceByHamburger", value6);

			var value7 = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

			var value8 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

			var value9 = _productService.TProductPriceBySteakBurger();
			await Clients.All.SendAsync("ReceiveProductPriceBySteakBurger", value9);

			var value10 = _productService.TTotalPriceByDrinkCategory();
			await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value10);

			var value11 = _productService.TTotalPriceBySaladCategory();
			await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value11);

		}

		public async Task GetBookingList()
		{
			var values=_bookingSevice.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}

		public async Task SendNotification()
		{
			var values=_notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", values);

			var notificationListByFalse=_notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse",notificationListByFalse);
		}
		
		public async Task GetMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}
		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
       
        public override Task OnConnectedAsync()
        {
            Interlocked.Increment(ref clientCount);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Interlocked.Decrement(ref clientCount);
            return base.OnDisconnectedAsync(exception);
        }

        public Task<int> GetClientCount()
        {
            return Task.FromResult(clientCount);
        }

    }
}
