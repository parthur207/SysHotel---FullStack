using SysHotel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.ResponsePattern
{
    public class ResponseModel<T>
    {
        public ResponseModel() { }

        public string? Message { get; set; }

        public ResponseStatusEnum Status { get; set; }

        public T Content { get; set; }  
    }
}
