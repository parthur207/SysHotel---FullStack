using Microsoft.EntityFrameworkCore;
using SysHotel.Application.DTOs;
using SysHotel.Application.RepositoriesInterface;
using SysHotel.Domain.Entities;
using SysHotel.Domain.Enums;
using SysHotel.Domain.ResponsePattern;
using SysHotel.Infrastrucuture.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.RepositoriesServices
{
    public class HotelUnitRepository : IHotelUnitRepositoryInterface
    {

        private readonly DbContextSysHotel _dbContextSysHotel;

        public HotelUnitRepository(DbContextSysHotel dbContextSysHotel)
        {
            _dbContextSysHotel= dbContextSysHotel;
        }

        public async Task<ResponseModel<List<HotelUnitEntity>>> GetAllHotelsAsync()
        {
            var Response= new ResponseModel<List<HotelUnitEntity>>();
            try
            {
                var HotelsUnitsList = await _dbContextSysHotel.HotelUnit
                    .Include(x=>x.BookingsList.Count)
                    .ToListAsync();

                if (HotelsUnitsList is null || !HotelsUnitsList.Any())
                {

                    Response.Message = "Nenhum hotel cadastrado.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                Response.Status= ResponseStatusEnum.Success;
                Response.Content = HotelsUnitsList;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.CriticalError;
                Response.Message = "Ocorreu um erro inesperado.";

                Debug.WriteLine("Ocorreu um erro inesperado: "+ ex.Message);
            }
            return Response;
        }
    }
}
