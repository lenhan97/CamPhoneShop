using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class SlideQuery:IPaging,ISorting
    {
        public bool? TrangThai { get; set; } = null;

        public string SortBy { get; set; } = "IdSlide";
        public string Order { get; set; } = "asc";
        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
    }
}
