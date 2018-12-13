using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class DanhMucSPQuery:IPaging,ISorting
    {
        public bool? TinhTrang { get; set; } = null;

        public string SortBy { get; set; } = "TenDM";
        public string Order { get; set; } = "asc";
        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
    }
}
