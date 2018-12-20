using System;
using WebMobileMVC.Helpers;

namespace WebMobileMVC.Models
{
    public class GioHangModel
    {
        public ListModel<SanPham> dsSanPham { get; set; } = new ListModel<SanPham>();
    }
}
