using SysHotel.Application.DTOs;
using SysHotel.Application.Models;
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
    public interface IUserRepositoryInterface
    {
        //Queries
        Task<ResponseModel<UserEntity>> GetUserByIdAsync(Guid UserId);
        Task<ResponseModel<UserEntity>> GetUserByEmailAsync(EmailVO Email);


        //Commands

        Task<SimpleResponseModel> InactiveUserByEmailAsync(EmailVO Email);
        Task<SimpleResponseModel> ActiveUserByEmailAsync(EmailVO Email);

        Task<SimpleResponseModel> ChangePasswordAsync(Guid UserId, string PasswordCurrent, string NewPassword);
    }
}
