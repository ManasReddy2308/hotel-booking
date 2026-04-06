using System.ComponentModel.DataAnnotations;

namespace hotel_booking_backend.Models
{
	public class User
	{
		[Key]
		public int UserId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Email { get; set; } = string.Empty;

		public string Password { get; set; } = string.Empty;

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}
}