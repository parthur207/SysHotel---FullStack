using SysHotel.Domain.Enums;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.Entities
{
    public class UserEntity
    {

        public UserEntity(string email, PasswordHashVO Password)
        {
            Email = email;
            PasswordHash = Password;
        }

        public UserEntity(string name, DateOnly bithDate, int phoneNumber, int cEP, string state, string city, string anddress, string email, PasswordHashVO password)
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
            CreatedAt = DateTime.Now;
            Active = true;
        }
        public Guid UserId { get; private set; }
        public string Name { get; private set; }
        public DateOnly BithDate { get; private set; }
        public int PhoneNumber { get; private set; }
        public int CEP { get; private set; }
        public string State { get; private set; }
        public string City { get; private set; }
        public string Anddress { get; private set; }
        public string Email { get; private set; }
        public PasswordHashVO PasswordHash { get; private set; }
        public List<BookingEntity>? BookingHistory { get; private set; }
        public  bool Active { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public SimpleResponseModel SetToInactive()
        {
          
            if (Active)
            {
                Active = false;
                return new SimpleResponseModel { Status = ResponseStatusEnum.Success };
            }
            else
            {
                return new SimpleResponseModel { Messsage = "O usuário já está inativo.", Status = ResponseStatusEnum.Error };

            }
        }
    }
}
