using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;
using System.Net;
using System.Net.Mail;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]

		public IActionResult Index(CreateMailDto createMailDto)
		{
			// MailMessage nesnesi oluşturun
			using (var mail = new MailMessage())
			{
				mail.From = new MailAddress("ilhanboysan@gmail.com");
				mail.To.Add(createMailDto.ReceiverMail);
				mail.Subject = createMailDto.Subject;
				mail.Body = createMailDto.Body;

				// SmtpClient oluşturun ve yapılandırın
				using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
				{
					smtpClient.EnableSsl = true;
					smtpClient.Credentials = new NetworkCredential("ilhanboysan@gmail.com", "bfvg uogl lpru gxib");

					// E-postayı gönder
					smtpClient.Send(mail);
				}
			}

			// Başka bir sayfaya yönlendirin
			return RedirectToAction("Index", "Category");

		}

	}
}
