using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.Auth.Jwt
{
    public interface IJwtInterface
    {

        Task<int> GenerateToken();
    }
}
