using System;
namespace ThuongMaiDienTuAPI.Dtos
{
    public class QuangCaoDto
    {
        public string TenDoiTac { get; set; }
        public int IDLoaiQC { get; set; }
        public double GiaThue { get; set; }
        public string NguoiDaiDien { get; set; }
        public string Hinh { get; set; }
        public string URL { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
    }
}
