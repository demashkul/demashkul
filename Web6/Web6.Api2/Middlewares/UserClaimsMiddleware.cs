using System.Security.Claims;
using Web6.Jwt;

namespace Web6.Middlewares
{
    public class UserClaimsMiddleware
    {
        private readonly RequestDelegate next;
        public UserClaimsMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, IUserClaims userClaims)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                long id = Convert.ToInt64(context.User.Claims.First(i => i.Type == ClaimTypes.NameIdentifier).Value);
                string tckn = context.User.Claims.First(i => i.Type == ClaimTypes.Name).Value;
                string fullName = context.User.Claims.First(i => i.Type == ClaimTypes.GivenName).Value;
                int roleId = Convert.ToInt32(context.User.Claims.First(i => i.Type == ClaimTypes.Role).Value);
                string roleName = context.User.Claims.First(i => i.Type =="RoleName").Value;
                int locationId = Convert.ToInt32(context.User.Claims.First(i => i.Type == ClaimTypes.Locality).Value);

                userClaims.IsAuthenticated = true;
                userClaims.UserInfo = new UserInfo { Id = id, Tckn = tckn, Name = fullName, RoleId = roleId,LocationId=locationId ,RoleName=roleName};
            }
            await next(context);
        }
    }
}
