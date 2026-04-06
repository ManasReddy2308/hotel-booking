using Microsoft.AspNetCore.Mvc;
using hotel_booking_backend.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class RoomsController : ControllerBase
{
	private readonly AppDbContext _context;

	public RoomsController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet("byHotel/{hotelId}")]
	public async Task<IActionResult> GetRoomsByHotel(int hotelId)
	{
		var rooms = await _context.Rooms
			.Where(r => r.HotelId == hotelId)
			.ToListAsync();

		return Ok(rooms);
	}
}