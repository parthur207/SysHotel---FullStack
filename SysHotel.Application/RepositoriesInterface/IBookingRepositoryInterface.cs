using SysHotel.Domain.Entities;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.RepositoriesInterface
{
    public interface IBookingRepositoryInterface
    {
        //User
        Task<ResponseModel<List<BookingEntity>>> GetAllBookingsByUserId(int Size, Guid userId);

        //Adm
        Task<ResponseModel<List<BookingEntity>>> GetAllBookingsByEmail(EmailVO Email);

        Task<ResponseModel<BookingEntity>> GetBookingById(string BookingCodeId);

        


    }
}
