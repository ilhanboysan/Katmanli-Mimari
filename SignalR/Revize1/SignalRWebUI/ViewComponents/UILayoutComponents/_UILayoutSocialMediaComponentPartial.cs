using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDto;

namespace SignalRWebUI.ViewComponents.UILayoutComponents
{
	public class _UILayoutSocialMediaComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UILayoutSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7239/api/SocialMedia");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsondata);
				return View(values);

			}
			return View();
		}

	}
}
