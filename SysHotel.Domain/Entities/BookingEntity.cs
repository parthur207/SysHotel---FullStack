using SysHotel.Domain.Enums;
using SysHotel.Domain.ResponsePattern;
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
        public BookingEntity(string bookingCode, DateTime checkInDate, DateTime checkOutDate, decimal price, int floor, int roomNumber, List<string> guests)
        {
            CheckInDate = checkInDate; 
            CheckOutDate = checkOutDate;
            DatePurchase= DateTime.Now;

            BookingStatus = BookingStatusEnum.PendingPayment;
            Price = price;
            Floor = floor;
            RoomNumber = roomNumber;
            Guests.Add(User.Name);
            Guests = guests;
        }

        public string BookingCodeID { get; private set; } //PK
        public DateTime CheckInDate { get; private set; }
        public DateTime CheckOutDate { get; private set; }
        public DateTime DatePurchase { get; private set; }
        public BookingStatusEnum BookingStatus { get; private set; }
        public Decimal Price { get; private set; }
        public Guid HotelUnitID { get; private set; } //PF

        public HotelUnitEntity HotelUnit { get; private set; }
        public int Floor { get; private set; }
        public int RoomNumber { get; private set; }
        public List<string> Guests { get; private set; }
        public Guid UserId { get;  private set; } //PF
        public UserEntity User { get; private set; }

        public void AssignUserId(Guid userId)
        {
            UserId = userId;
        }

        public SimpleResponseModel ConfirmPayment()
        {
            if(BookingStatus is BookingStatusEnum.Reservaded)
            {
                return new SimpleResponseModel { Status = ResponseStatusEnum.Error, Messsage="O pagamento já foi realizado." };
            }
            else if(BookingStatus is BookingStatusEnum.Canceled)
            {
                return new SimpleResponseModel { Status = ResponseStatusEnum.Error, Messsage = "A reserva se encontra cancelada." };

            }
            else if (BookingStatus is BookingStatusEnum.Attended)
            {
                return new SimpleResponseModel { Status = ResponseStatusEnum.Error, Messsage = "A reserva já foi utilizada;." };

            }
            else
            {
                BookingStatus = BookingStatusEnum.Reservaded;
                return new SimpleResponseModel { Status = ResponseStatusEnum.Success, Messsage = "Pagemento confirmado com sucesso." };
            }
        }
    }
}
