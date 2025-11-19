using SysHotel.Application.DTOs;
using SysHotel.Domain.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Application.RepositoriesInterface
{
    public interface HotelUnitRepositoryInterface
    {

        Task<ResponseModel<List<HotelUnitDTO>>> GetAllHotelsAsync();
    }
}
