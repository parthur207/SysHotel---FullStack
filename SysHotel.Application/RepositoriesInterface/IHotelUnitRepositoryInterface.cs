using SysHotel.Application.DTOs;
using SysHotel.Domain.Entities;
using SysHotel.Domain.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.RepositoriesInterface
{
    public interface IHotelUnitRepositoryInterface
    {

        Task<ResponseModel<List<HotelUnitEntity>>> GetAllHotelsAsync();
    }
}
