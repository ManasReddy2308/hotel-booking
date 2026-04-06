using Microsoft.EntityFrameworkCore;
using hotel_booking_backend.Models;

namespace hotel_booking_backend.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		public DbSet<User> Users { get; set; }

		public DbSet<Hotel> Hotels { get; set; }

		public DbSet<Room> Rooms { get; set; }

		public DbSet<Booking> Bookings { get; set; }
	}
}