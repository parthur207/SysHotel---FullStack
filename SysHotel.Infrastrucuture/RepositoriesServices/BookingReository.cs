using SysHotel.Infrastrucuture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.RepositoriesServices
{
    internal class BookingReository
    {

        private readonly DbContextSysHotel _dbContextSysHotel;

        public BookingReository(DbContextSysHotel dbContextSysHotel)
        {
            _dbContextSysHotel = dbContextSysHotel;
        }

    }
}
