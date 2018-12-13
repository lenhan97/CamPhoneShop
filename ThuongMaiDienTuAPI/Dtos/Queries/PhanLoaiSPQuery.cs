using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class PhanLoaiSPQuery : ISorting
    {
        public string SortBy { get; set; } = "SLMua";
        public string Order { get; set; } = "desc";
    }
}
