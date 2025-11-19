using SysHotel.Application.RepositoriesInterface;
using SysHotel.Domain.Entities;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Domain.ValueObjects;
using SysHotel.Infrastrucuture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.RepositoriesServices
{
    public class BookingRepository : IBookingRepositoryInterface
    {

        private readonly DbContextSysHotel _dbContextSysHotel;

        public BookingRepository(DbContextSysHotel dbContextSysHotel)
        {
            _dbContextSysHotel = dbContextSysHotel;
        }

        public Task<ResponseModel<List<BookingEntity>>> GetAllBookingsByEmail(EmailVO Email)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<BookingEntity>>> GetAllBookingsByUserId(int Size = 5)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<BookingEntity>> GetBookingById(string BookingCodeId)
        {
            throw new NotImplementedException();
        }


    }
}
