using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotel_booking_backend.Data;
using hotel_booking_backend.Models;
using System.Security.Claims;

namespace hotel_booking_backend.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class BookController : ControllerBase
	{
		private readonly AppDbContext _context;

		public BookController(AppDbContext context)
		{
			_context = context;
		}


		// ✅ Get Logged-in User Bookings
		[HttpGet("my-bookings")]
		public async Task<IActionResult> GetUserBookings()
		{
			try
			{
				var email = User.FindFirst(ClaimTypes.Email)?.Value;

				if (string.IsNullOrEmpty(email))
					return Unauthorized();

				var user = await _context.Users
					.FirstOrDefaultAsync(u => u.Email == email);

				if (user == null)
					return NotFound("User not found");


				var bookings = await _context.Bookings
					.Include(b => b.Room)
					.ThenInclude(r => r.Hotel)
					.Where(b => b.UserId == user.UserId)
					.OrderByDescending(b => b.CreatedAt)
					.ToListAsync();


				return Ok(bookings);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}



		// ✅ Cancel Booking
		[HttpPut("cancel/{bookingId}")]
		public async Task<IActionResult> CancelBooking(int bookingId)
		{
			try
			{
				var booking = await _context.Bookings
					.FirstOrDefaultAsync(b => b.BookingId == bookingId);


				if (booking == null)
					return NotFound("Booking not found");


				booking.Status = "Cancelled";

				await _context.SaveChangesAsync();


				return Ok(new
				{
					message = "Booking Cancelled Successfully"
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}



		// ✅ Get Booking By Id
		[HttpGet("{bookingId}")]
		public async Task<IActionResult> GetBooking(int bookingId)
		{
			var booking = await _context.Bookings
				.Include(b => b.Room)
				.ThenInclude(r => r.Hotel)
				.FirstOrDefaultAsync(b => b.BookingId == bookingId);

			if (booking == null)
				return NotFound();

			return Ok(booking);
		}
	}
}