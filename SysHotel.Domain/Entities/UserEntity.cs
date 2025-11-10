using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.Entities
{
    public class UserEntity : BaseEntity
    {

        public UserEntity(string email, string Password)
        {
            Email = email;
            PasswordHash = Password;
        }

        public UserEntity(string name, DateOnly bithDate, int phoneNumber, int cEP, string state, string city, string anddress, string email, string password)
        {
            Name = name;
            BithDate = bithDate;
            PhoneNumber = phoneNumber;
            CEP = cEP;
            State = state;
            City = city;
            Anddress = anddress;
            Email = email;
            PasswordHash= password;
            BookingHistory = new List<BookingEntity>();
        }

        public string Name { get; set; }
        public DateOnly BithDate { get; set; }
        public int PhoneNumber { get; set; }
        public int CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Anddress { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<BookingEntity>? BookingHistory { get; set; }
    }
}
