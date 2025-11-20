using SysHotel.Application.Interfaces.IUseCases.User;
using SysHotel.Application.RepositoriesInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.UseCases.Queries
{
    public class UserQueriesAdm : IUserQueriesAdmInterface
    {  
        
        private readonly IUserRepositoryInterface _userRepositoryInterface;
        private readonly ImAPPER
        public UserQueriesAdm(IUserRepositoryInterface userRepositoryInterface)
        {
            _userRepositoryInterface= userRepositoryInterface;
        }


    }
}
