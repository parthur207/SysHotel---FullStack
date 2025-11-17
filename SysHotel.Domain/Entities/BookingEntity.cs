using SysHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.Entities
{
    public class BookingEntity
    {
        public BookingEntity(BookingCodeVO bookingCode, DateTime checkInDate, DateTime checkOutDate, decimal price, int floor, int roomNumber, List<string> guests)
        {
            CheckInDate = checkInDate; 
            CheckOutDate = checkOutDate;
            DatePurchase= DateTime.Now;
            Price = price;
            Floor = floor;
            RoomNumber = roomNumber;
            Guests = guests;
        }

        public BookingCodeVO BookingCode { get; set; } //PK
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime DatePurchase { get; set; }
        public Decimal Price { get; set; }
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public List<string> Guests { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; }

        public void AssignUserId(Guid userId)
        {
            UserId = userId;
        }
    }
}
