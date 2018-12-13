using System.Linq;
using System.Security.Claims;

namespace ThuongMaiDienTuAPI.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetIdUser(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "IdUser").Value);
        }

        public static int GetIdCustomer(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "IdCustomer").Value);
        }

        public static int GetIdSeller(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "IdSeller").Value);
        }
    }
}
