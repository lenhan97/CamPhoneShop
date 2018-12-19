using System.Linq;
using System.Security.Claims;

namespace ThuongMaiDienTuAPI.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetIdUser(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "ID").Value);
        }

        public static int GetIdCustomer(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "IDCustomer").Value);
        }

        public static int GetIdSeller(this ClaimsPrincipal user)
        {
            return int.Parse(user.Claims.FirstOrDefault(c => c.Type == "IDSeller").Value);
        }
    }
}
