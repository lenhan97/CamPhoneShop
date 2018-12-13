using System.Linq;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Helpers
{
    public class Paging<T>
    {
        public static IQueryable<T> Get(IQueryable<T> query,IPaging page)
        {
            return query.Skip(page.PageSize * (page.Page - 1)).Take(page.PageSize);
        }
    }
}
