using System.ComponentModel.DataAnnotations;

namespace ThuongMaiDienTuAPI.Entities
{
    public class ChiTietHD
    {
        [Key]
        public int IDHoaDon { get; set; }
        [Key]
        public int IDPhanLoaiSP { get; set; }
        public int? SoLuong { get; set; }
        public double? Gia { get; set; }
        public double? GiaKM { get; set; }
    }
}
