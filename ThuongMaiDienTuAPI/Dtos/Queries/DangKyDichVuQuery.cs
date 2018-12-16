using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class DangKyDichVuQuery : ISorting, IPaging
    {
        public int? ID { get; set; } = null;
        public int? IDSeller { get; set; } = null;
        public int? IDGoiDichVu { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "ThoiGianDangKy";
        public string Order { get; set; } = "desc";
    }
}
