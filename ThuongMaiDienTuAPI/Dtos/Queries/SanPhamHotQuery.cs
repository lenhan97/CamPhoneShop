using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class SanPhamHotQuery : ISorting
    {
        public string SortBy { get; set; } = "SLXem";
        public string Order { get; set; } = "desc";
    }
}
