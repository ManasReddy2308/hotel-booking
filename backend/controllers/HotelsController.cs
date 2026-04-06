using Microsoft.AspNetCore.Mvc;
using hotel_booking_backend.Data;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class HotelsController : ControllerBase
{
	private readonly AppDbContext _context;

	public HotelsController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetHotels()
	{
		var hotels = await _context.Hotels.ToListAsync();
		return Ok(hotels);
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetHotel(int id)
	{
		var hotel = await _context.Hotels
			.Include(r => r.Rooms)
			.FirstAsync(h => h.HotelId == id);

		////if (hotel == null) return NotFound();

		return Ok(hotel);
	}
}