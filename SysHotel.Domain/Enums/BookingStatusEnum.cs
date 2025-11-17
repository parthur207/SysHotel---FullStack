using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Domain.Enums
{
    public enum BookingStatusEnum
    {
        PendingPayment=1,
        Reservaded = 2,
        Canceled=3,
        Attended= 4,
        NoShow=5,
    }
}
