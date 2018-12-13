using System.Linq;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Helpers
{
    public class Sorting<T>
    {
        public static IQueryable<T> Get(IQueryable<T> query, ISorting sort)
        {
            sort.Order = sort.Order.ToLower();
            if (sort.Order.Equals("desc"))
                return query.OrderByDescending(x => ReflectionProperty.Get(x, sort.SortBy).GetValue(x, null));
            else
                return query.OrderBy(x => ReflectionProperty.Get(x, sort.SortBy).GetValue(x, null));
        }
    }
}
