using SysHotel.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysHotel.Infrastrucuture.Auth.Jwt
{
    public interface IJwtInterface
    {
        string GenerateToken(Guid userId, UserRoleEnum Role);
    }
}
