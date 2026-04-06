using System.ComponentModel.DataAnnotations;

namespace hotel_booking_backend.Models
{
	public class Hotel
	{
		[Key]
		public int HotelId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Location { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public DateTime CreatedAt { get; set; } = DateTime.Now;

		public ICollection<Room> Rooms { get; set; } = new List<Room>();
	}
}