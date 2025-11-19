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
                    Response.Status=ResponseStatusEnum.NotFound;
                    return Response;
                }

                var ActiveUser = user.SetToActive();

                if (!ActiveUser.Status.Equals(ResponseStatusEnum.Success))
                {

                    Response.Message = "O usuário já está ativado.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                Response.Status= ResponseStatusEnum.Success;
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

        public async Task<SimpleResponseModel> CreateUserAsync(UserEntity User)
        {
            var Response= new SimpleResponseModel();
            try
            {
                if (User == null)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "Existem dados de cadastro nulos.";
                }
            
                if (await _dbContextSysHotel.User.AnyAsync(x=>x.Email.Endereco==User.Email))
                {
                    Response.Message = "Ocorreu um erro inesperado.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                await _dbContextSysHotel.User.AddAsync(User);
                await _dbContextSysHotel.SaveChangesAsync();

                Response.Status = ResponseStatusEnum.Success;
                Response.Message = "Cadastro realizado com sucesso.";

            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine(ex.Message);
            }
            return Response;
        }

        public async Task<ResponseModel<UserDTO>> GetUserByEmailAsync(EmailVO Email)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<UserEntity>> GetUserByIdAsync(Guid userId)
        {
            var Response= new ResponseModel<UserEntity>();
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
                    Response.Status = ResponseStatusEnum.Error ;
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

        public async Task<ResponseModel<UserEntity>> LoginAsync(UserEntity User)
        {
            var Response= new ResponseModel<UserEntity>();    

            try
            {
                if (User is null)
                {
                    Response.Status= ResponseStatusEnum.Error;
                    return Response;
                }

                var UserLogin = await _dbContextSysHotel.User
                    .Where(x => x.Email.Endereco == User.Email.Endereco && x.PasswordHash == User.PasswordHash)
                    .FirstOrDefaultAsync();

                if (UserLogin == null)
                {
                    Response.Status=ResponseStatusEnum.Error;
                    Response.Message = "Credenciais inválidas.";
                    return Response;
                }

                Response.Content = UserLogin;
                Response.Status = ResponseStatusEnum.Success;
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
