using Microsoft.EntityFrameworkCore;
using SysHotel.Application.DTOs;
using SysHotel.Application.RepositoriesInterface;
using SysHotel.Domain.Entities;
using SysHotel.Domain.Enums;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Domain.ValueObjects;
using SysHotel.Infrastrucuture.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.RepositoriesServices
{
    public class UserRepository : IUserRepositoryInterface
    {

        private readonly DbContextSysHotel _dbContextSysHotel;

        public UserRepository(DbContextSysHotel dbContextSysHotel)
        {
            _dbContextSysHotel = dbContextSysHotel;
        }

        public async Task<SimpleResponseModel> ActiveUserByEmailAsync(EmailVO email)
        {
            var Response = new SimpleResponseModel();
            try
            {
                var user = await _dbContextSysHotel.User
                    .Where(x => x.Email.Endereco == email.Endereco)
                    .FirstOrDefaultAsync();

                if (user is null)
                {
                    Response.Message = "O e-mail informado não existe.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                var ActiveUser = user.SetToActive();

                if (!ActiveUser.Status.Equals(ResponseStatusEnum.Success))
                {

                    Response.Message = "O usuário já está ativado.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                Response.Status = ResponseStatusEnum.Success;
                Response.Message = "Usuário ativado com sucesso.";
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine(ex.Message);
            }
            return Response;
        }

        public async Task<SimpleResponseModel> ChangePasswordAsync(Guid UserId, string PasswordCurrent, string NewPassword)
        {
            throw new NotImplementedException();
        }


        public async Task<ResponseModel<UserEntity>> GetUserByEmailAsync(EmailVO Email)
        {
            var Response= new ResponseModel<UserEntity>();
            try
            {
                var user = await _dbContextSysHotel.User.FirstOrDefaultAsync(x=>x.Email.Endereco==Email.Endereco);

                if (user is null)
                {
                    Response.Message = "O e-mail informado não existe.";
                    Response.Status= ResponseStatusEnum.NotFound;
                    return Response;
                }

                Response.Status= ResponseStatusEnum.Success;
                Response.Content = user;
            }
            catch (Exception ex)
            {
                Response.Status= ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
            return Response;
        }

        public async Task<ResponseModel<List<UserEntity>>> GetAllUsersAsync(int page, int size)
        {
            var Response = new ResponseModel<List<UserEntity>>();
            try
            {
                var usersList = await _dbContextSysHotel.User.ToListAsync();

                if (usersList is null || !usersList.Any())
                {
                    Response.Message = "Nenhum usuário foi encontrado.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                Response.Status = ResponseStatusEnum.Success;
                Response.Content = usersList;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
            }
            return Response;
        }


        public async Task<ResponseModel<UserEntity>> GetUserByIdAsync(Guid userId)
        {
            var Response = new ResponseModel<UserEntity>();
            try
            {
                var User = await _dbContextSysHotel.User
                    .Where(x => x.UserId == userId)
                     .Include(x => x.BookingHistory)
                     .ThenInclude(x => x.HotelUnit)
                     .FirstOrDefaultAsync();

                if (User is null)
                {
                    Response.Message = "Ocorreu um erro inesperado.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                Response.Status = ResponseStatusEnum.Success;
                Response.Content = User;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine(ex.Message);
            }
            return Response;
        }

        public async Task<SimpleResponseModel> InactiveUserByEmailAsync(EmailVO email)
        {
            var Response = new SimpleResponseModel();
            try
            {
                var user = await _dbContextSysHotel.User
                    .Where(x => x.Email.Endereco == email.Endereco)
                    .FirstOrDefaultAsync();

                if (user is null)
                {
                    Response.Message = "O e-mail informado não existe.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                var ActiveUser = user.SetToInactive();

                if (!ActiveUser.Status.Equals(ResponseStatusEnum.Success))
                {

                    Response.Message = "O usuário já está inativo.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                Response.Status = ResponseStatusEnum.Success;
                Response.Message = "Usuário ativado com sucesso.";
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine(ex.Message);
            }
            return Response;
        }

    }
}
