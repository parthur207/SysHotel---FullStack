using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.Models
{
    public class CreateBookingModel
    {
        public int Floor { get; set; }
        public int RoomNumber { get; set; }
        public List<string> Guests { get; set; }


    }
}
