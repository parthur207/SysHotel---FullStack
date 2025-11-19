using Microsoft.EntityFrameworkCore;
using SysHotel.Application.RepositoriesInterface;
using SysHotel.Domain.Entities;
using SysHotel.Domain.Enums;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Infrastrucuture.Auth.Jwt;
using SysHotel.Infrastrucuture.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.Auth.AuthRepositories
{
    public class UserAuthRepository : IUserAuthRepositoryInterface
    {

        private readonly DbContextSysHotel _dbContextSysHotel;
        private readonly IJwtInterface _jwtInterface;
        public UserAuthRepository(DbContextSysHotel dbContextSysHotel, IJwtInterface jwtInterface)
        {
            _dbContextSysHotel= dbContextSysHotel;
            _jwtInterface= jwtInterface;
        }

        public async Task<ResponseModel<string>> LoginAsync(UserEntity User)
        {
            var Response = new ResponseModel<string>();

            try
            {
                if (User is null)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                var UserLogin = await _dbContextSysHotel.User
                    .Where(x => x.Email.Endereco == User.Email.Endereco && x.PasswordHash == User.PasswordHash)
                    .FirstOrDefaultAsync();

                if (UserLogin == null)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "Credenciais inválidas.";
                    return Response;
                }

                var TokenJWT = _jwtInterface.GenerateToken(UserLogin.UserId, UserLogin.Role);

                Response.Content = TokenJWT;
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
        public async Task<SimpleResponseModel> CreateUserAsync(UserEntity newUser)
        {
            var Response = new SimpleResponseModel();
            try
            {
                if (newUser == null)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "Existem dados de cadastro nulos.";
                }

                if (await _dbContextSysHotel.User.AnyAsync(x => x.Email.Endereco == newUser.Email))
                {
                    Response.Message = "Ocorreu um erro inesperado.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                await _dbContextSysHotel.User.AddAsync(newUser);
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
    }
}
