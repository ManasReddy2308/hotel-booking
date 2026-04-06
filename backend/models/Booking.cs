using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_booking_backend.Models
{
	public class Booking
	{
		[Key]
		public int BookingId { get; set; }

		public int UserId { get; set; }

		public int RoomId { get; set; }

		public DateTime CheckInDate { get; set; }

		public DateTime CheckOutDate { get; set; }

		public decimal TotalPrice { get; set; }

		public string Status { get; set; } = "Booked";

		public DateTime CreatedAt { get; set; } = DateTime.Now;


		[ForeignKey("UserId")]
		public User? User { get; set; }   // ✅ Make Nullable

		[ForeignKey("RoomId")]
		public Room? Room { get; set; }   // ✅ Make Nullable
	}
}