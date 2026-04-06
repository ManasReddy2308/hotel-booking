using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hotel_booking_backend.Data;
using hotel_booking_backend.Models;
using hotel_booking_backend.DTOs;
using hotel_booking_backend.Services;

namespace hotel_booking_backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly AppDbContext _context;
		private readonly JwtService _jwt;

		public AuthController(AppDbContext context, JwtService jwt)
		{
			_context = context;
			_jwt = jwt;
		}

		// ✅ REGISTER
		[HttpPost("register")]
		public async Task<IActionResult> Register(RegisterDto dto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var existingUser = await _context.Users
					.FirstOrDefaultAsync(u => u.Email == dto.Email);

				if (existingUser != null)
					return BadRequest("Email already exists");

				var user = new User
				{
					Name = dto.Name,
					Email = dto.Email,
					Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
					CreatedAt = DateTime.Now
				};

				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync();

				return Ok(new { message = "User registered successfully" });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Server error: {ex.Message}");
			}
		}

		// ✅ LOGIN
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginDto dto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest(ModelState);

				var user = await _context.Users
					.FirstOrDefaultAsync(u => u.Email == dto.Email);

				if (user == null)
					return Unauthorized("Invalid email");

				bool isValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.Password);

				if (!isValid)
					return Unauthorized("Invalid password");

				var token = _jwt.GenerateToken(user.Email);

				return Ok(new
				{
					token,
					user.UserId,
					user.Name,
					user.Email
				});
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Server error: {ex.Message}");
			}
		}

		// ✅ GUEST LOGIN
		[HttpGet("guest")]
		public IActionResult GuestLogin()
		{
			return Ok(new
			{
				message = "Guest login successful",
				role = "Guest"
			});
		}
	}
}