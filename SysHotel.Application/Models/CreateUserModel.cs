using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.Models
{
    public class CreateUserModel
    {

        public string Name { get; set; }
        public DateOnly BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public int CEP { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
