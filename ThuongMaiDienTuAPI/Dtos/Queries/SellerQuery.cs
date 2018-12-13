
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class SellerQuery:IPaging,ISorting
    {
        public string CMND { get; set; } = null;
        public string Mail { get; set; } = null;
        public string TenSeller { get; set; } = null;
        public bool? CheckMail { get; set; } = null;
        public bool? CheckCMND { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "NgayDK";
        public string Order { get; set; } = "desc";
    }
}
