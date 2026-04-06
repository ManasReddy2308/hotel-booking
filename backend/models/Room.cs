using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hotel_booking_backend.Models
{
	public class Room
	{
		[Key]
		public int RoomId { get; set; }

		public int HotelId { get; set; }

		public string RoomType { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public int Capacity { get; set; }

		public bool IsAvailable { get; set; } = true;


		[ForeignKey("HotelId")]
		public Hotel Hotel { get; set; }

		public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
	}
}