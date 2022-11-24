using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web6.Jwt
{
    public interface IJwtService
    {
        //sample comment
        Task<string> GenerateToken(long id, string tckn, string name, int roleId,string roleName,long locationId);
    }
}
