using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class DanhGiaQuery : IPaging, ISorting
    {
        public double? FromDanhGia { get; set; } = null;
        public double? ToDanhGia { get; set; } = null;
        public int? IdSeller { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "Ngay";
        public string Order { get; set; } = "desc";
    }
}
