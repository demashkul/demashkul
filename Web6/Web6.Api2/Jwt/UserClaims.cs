using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web6.Jwt
{
    public class UserClaims : IUserClaims
    {
        public bool IsAuthenticated { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
