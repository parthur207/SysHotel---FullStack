using SysHotel.Application.Interfaces.IUseCases.User;
using SysHotel.Application.RepositoriesInterface;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.UseCases.Queries
{
    public class UserQueries : IUserQueriesInterface
    {

        private readonly IUserRepositoryInterface _userRepository;
        public UserQueries(IUserRepositoryInterface userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<SimpleResponseModel> GetAllUsers(int page, int size)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> GetUserByEmail(EmailVO UserEmail)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> GetUserById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
