
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class UserQuery : IPaging, ISorting
    {
        public string TenDN { get; set; } = null;
        public bool? TrangThai { get; set; } = null;
        public string LoaiUser { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "TenDN";
        public string Order { get; set; } = "asc";
    }
}
