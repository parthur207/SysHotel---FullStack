using SysHotel.Domain.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.Interfaces.IUseCases.Booking
{
    public interface IBookingCommandsAdmInterface
    {

        Task<SimpleResponseModel> BuyBooking(C);
    }
}
