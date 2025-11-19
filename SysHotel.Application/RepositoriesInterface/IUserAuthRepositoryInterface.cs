using SysHotel.Domain.Entities;
using SysHotel.Domain.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.RepositoriesInterface
{
    public interface IUserAuthRepositoryInterface
    {

        Task<SimpleResponseModel> CreateUserAsync(UserEntity NewUser);

        Task<ResponseModel<string>> LoginAsync(UserEntity UserLogin);
    }
}
