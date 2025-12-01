using SysHotel.Domain.ResponsePattern;
using SysHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.Interfaces.IUseCases.User
{
    public interface IUserQueriesInterface
    {

        Task<SimpleResponseModel> GetUserByEmail(EmailVO UserEmail);

        Task<SimpleResponseModel> GetUserById(Guid Id);

        Task<SimpleResponseModel> GetAllUsers(int page, int size);

    }
}
