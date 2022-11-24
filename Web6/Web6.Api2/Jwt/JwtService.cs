using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Web6.Jwt
{
    public class JwtService : IJwtService
    {
        private readonly JwtTokenConfiguration _jwtTokenConfiguration;
        public JwtService(JwtTokenConfiguration jwtTokenConfiguration)
        {
            _jwtTokenConfiguration = jwtTokenConfiguration;
        }
        //sample comment
        public async Task<string> GenerateToken(long id, string tckn, string name, int roleId,string roleName,long locationId)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier,id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name,tckn));
            claims.Add(new Claim(ClaimTypes.GivenName, name));
            claims.Add(new Claim(ClaimTypes.Role, roleId.ToString()));
            claims.Add(new Claim(ClaimTypes.Locality, locationId.ToString()));
            claims.Add(new Claim("RoleName", roleName));

            var token = new JwtSecurityToken(
                    _jwtTokenConfiguration.Issuer,
                    _jwtTokenConfiguration.Audience,
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(_jwtTokenConfiguration.Expires),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenConfiguration.SecretKey)),SecurityAlgorithms.HmacSha256));

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return await Task.FromResult(tokenString);
        }
    }
}
