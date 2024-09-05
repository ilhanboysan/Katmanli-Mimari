using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingSevice _bookingSevice;

        public BookingController(IBookingSevice bookingSevice)
        {
            _bookingSevice = bookingSevice;
        }
        [HttpGet]
        public IActionResult BookingList() 
        {
            var values=_bookingSevice.TGetListAll();
            return Ok(values); 
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Mail = createBookingDto.Mail,
                Date = createBookingDto.Date,
                Name = createBookingDto.Name,
                PersonCount = createBookingDto.PersonCount,
                Phone = createBookingDto.Phone,
                Description = createBookingDto.Description
            };
            _bookingSevice.TAdd(booking);
            return Ok("Rezervasyon Yapıldı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values=_bookingSevice.TGetByID(id);
            _bookingSevice.TDelete(values);
            return Ok("Rezervasyon İptal Edildi");

        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                Date = updateBookingDto.Date,
                
                Name = updateBookingDto.Name,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Phone = updateBookingDto.Phone,
                BookingID=updateBookingDto.BookingID,
            };
            _bookingSevice.TUpdate(booking);
            return Ok("Rezervasyon Güncellendi");

        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingSevice.TGetByID(id);
            return Ok(value); 
        }
        [HttpGet("BookingStatusApproved/{id}")]
        public IActionResult BookingStatusApproved(int id)
        {
            _bookingSevice.BookingStatusApproved(id);
            return Ok("Rezervasyon Açıklaması Güncellendi.");
        }
		[HttpGet("BookingStatusCanceled/{id}")]
		public IActionResult BookingStatusCanceled(int id)
		{
			_bookingSevice.BookingStatusCanceled(id);
			return Ok("Rezervasyon Açıklaması Güncellendi.");
		}






	}
}
