using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.Entities
{
    public class HotelUnitEntity
    {
        public HotelUnitEntity(string Name, int cEP, string address, string city, string state) 
        {
            this.Name = Name;
            this.CEP = cEP;
            this.Address = address;
            this.City = city;
            this.State = state;
            IsActive = true;
            BookingsList=new List<BookingEntity>();
        }

        public Guid HotelID { get; private set; }

        public string Name { get; private set; }
        public int CEP { get; private set; }

        public string Address {  get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public bool IsActive { get; private set; }

        public List<BookingEntity> BookingsList { get; private set; }



    }
}
