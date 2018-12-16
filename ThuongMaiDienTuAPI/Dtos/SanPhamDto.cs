using System.Collections.Generic;

namespace ThuongMaiDienTuAPI.Dtos
{
    public class SanPhamDto
    {
        public string Ten { get; set; }
        public string TenKhac { get; set; } = "";
        public int IDDanhMuc { get; set; }

        public string Mota { get; set; }
        public string NoiDung { get; set; }
        public string Hinh { get; set; }
        public string HinhCT { get; set; }
        public int ThoiGianBH { get; set; }
        public bool TinhTrangHang { get; set; }

        public CauHinhDto CauHinh { get; set; }
        public List<PhanLoaiSPDto> PhanLoaiSP { get; set; }
    }
}
