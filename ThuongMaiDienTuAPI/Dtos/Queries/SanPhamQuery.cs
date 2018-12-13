using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class SanPhamQuery : IPaging, ISorting
    {

        public string Ten { get; set; } = null;
        public bool? TinhTrang { get; set; } = null;
        public int? IDSeller { get; set; } = null;

        public int? FromGiaKM { get; set; } = null;
        public int? ToGiaKM { get; set; } = null;

        public int? FromSoLuong { get; set; } = null;
        public int? ToSoLuong { get; set; } = null;
        public int? IDDanhMuc { get; set; } = null;

        public string SortBy { get; set; } = "SLXem";
        public string Order { get; set; } = "desc";
        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
    }
}
