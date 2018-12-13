using System;

namespace ThuongMaiDienTuAPI.Dtos
{
    public class DanhGiaDto
    {
        public DateTime Ngay { get; set; }
        public string NoiDung { get; set; }
        public double Danhgia { get; set; }
        public int IDSeller { get; set; }
        public int IDUser { get; set; }
    }
}
