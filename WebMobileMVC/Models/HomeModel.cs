using WebMobileMVC.Helpers;

namespace WebMobileMVC.Models
{
    public class HomeModel
    {
        public ListModel<DanhMucSP> dsDanhMuc { get; set; } = new ListModel<DanhMucSP>();
        public ListModel<SanPham> dsSanPhamHot { get; set; } = new ListModel<SanPham>();
        public ListModel<SanPham> dsSanPhamSearch { get; set; } = new ListModel<SanPham>();
    }
}
