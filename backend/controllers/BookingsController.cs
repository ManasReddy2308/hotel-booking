using Microsoft.AspNetCore.Mvc;
using hotel_booking_backend.Data;
using hotel_booking_backend.Models;
using Microsoft.AspNetCore.Authorization;
[Authorize]
[ApiController]
[Route("api/[controller]")]

public class BookingsController : ControllerBase
{
	private readonly AppDbContext _context;

	public BookingsController(AppDbContext context)
	{
		_context = context;
	}


	[HttpGet("availability")]
	public IActionResult CheckAvailability(int roomId, DateTime checkIn, DateTime checkOut)
	{
		var exists = _context.Bookings.Any(b =>
			b.RoomId == roomId &&
			(checkIn < b.CheckOutDate && checkOut > b.CheckInDate)
		);

		return Ok(!exists);
	}


	[HttpPost]
	public IActionResult BookRoom([FromBody] Booking booking)
	{
		if (booking == null)
			return BadRequest("Invalid data");


		var exists = _context.Bookings.Any(b =>
			b.RoomId == booking.RoomId &&
			(booking.CheckInDate < b.CheckOutDate && booking.CheckOutDate > b.CheckInDate)
		);

		if (exists)
			return BadRequest("Room not available");

		booking.Status = "Booked";
		booking.CreatedAt = DateTime.Now;

		_context.Bookings.Add(booking);
		_context.SaveChanges();

		return Ok("Booking Successful");
	}
}