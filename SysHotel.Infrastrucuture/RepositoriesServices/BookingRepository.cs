using Microsoft.EntityFrameworkCore;
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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.RepositoriesServices
{
    public class BookingRepository : IBookingRepositoryInterface
    {

        private readonly DbContextSysHotel _dbContextSysHotel;

        public BookingRepository(DbContextSysHotel dbContextSysHotel)
        {
            _dbContextSysHotel = dbContextSysHotel;
        }

        public async Task<ResponseModel<List<BookingEntity>>> GetAllBookingsByEmail(EmailVO Email)
        {
            var Response = new ResponseModel<List<BookingEntity>>();
            try
            {
                if (!await _dbContextSysHotel.Booking.AnyAsync(x=>x.User.Email.Endereco==Email.Endereco))
                {
                    Response.Status=ResponseStatusEnum.Error;
                    Response.Message = "O e-mail em questão informado não existe.";
                    return Response;
                }

                var BookingsByEmail = await _dbContextSysHotel.Booking
                    .Include(x => x.HotelUnit.Name)
                    .Where(X => X.User.Email==Email.Endereco)
                    .ToListAsync();

                if (BookingsByEmail is null || !BookingsByEmail.Any())
                {
                    Response.Status=ResponseStatusEnum.NotFound;
                    Response.Message = "O e-mail em questão não está associado a nenhuma reserva.";
                    return Response;
                }

                Response.Content = BookingsByEmail;
                Response.Status = ResponseStatusEnum.Success;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine("Ocorreu um erro inesperado: "+ex.Message);
            }
            return Response;
        }

        public async Task<ResponseModel<List<BookingEntity>>> GetAllBookingsByUserId(int Size, Guid userId)
        {
            var Response = new ResponseModel<List<BookingEntity>>();
            try
            {
                if (!await _dbContextSysHotel.Booking.AnyAsync(x=>x.UserId==userId))
                {
                    Response.Message = "Id não encontrada.";
                    Response.Status=ResponseStatusEnum.Error;
                    return Response;
                }

                var bookingListById = await _dbContextSysHotel.Booking
                    .Where(x => x.UserId == userId)
                    .Include(x => x.HotelUnit)
                    .Take(Size)
                    .ToListAsync();

                if(bookingListById is null || !bookingListById.Any())
                {
                    Response.Message = "Nenhuma reserva encontrada.";
                    Response.Status= ResponseStatusEnum.NotFound;
                    return Response; 
                }

                Response.Status = ResponseStatusEnum.Success;
                Response.Content = bookingListById;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine(ex);
            }
            return Response;
        }

        public async Task<ResponseModel<BookingEntity>> GetBookingById(string bookingCodeID)
        {
            var Response = new ResponseModel<BookingEntity>();
            try
            {
                if (string.IsNullOrEmpty(bookingCodeID))
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "O código da reserva não pode ser nulo.";
                    return Response;
                }

                var booking = await _dbContextSysHotel.Booking
                   .Include(x => x.User)
                   .Include(x => x.HotelUnit)
                   .FirstOrDefaultAsync(x => x.BookingCodeID == bookingCodeID);

                if (booking is null)
                {
                    Response.Message = "O código informado não existe";
                    Response.Status=ResponseStatusEnum.NotFound;
                    return Response;
                }

              
                Response.Status = ResponseStatusEnum.Success;
                Response.Content = booking;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";
                Debug.WriteLine(ex);
            }
            return Response;
        }
    }
}
