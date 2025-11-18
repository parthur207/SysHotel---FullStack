using SysHotel.Infrastrucuture.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.RepositoriesServices
{
    public class UserRepository
    {

        private readonly DbContextSysHotel _dbContextSysHotel;

        public UserRepository(DbContextSysHotel dbContextSysHotel)
        {
            _dbContextSysHotel = dbContextSysHotel;
        }

    }
}
