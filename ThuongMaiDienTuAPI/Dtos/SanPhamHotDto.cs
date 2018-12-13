using System.Collections.Generic;
using ThuongMaiDienTuAPI.Entities;

namespace ThuongMaiDienTuAPI.Dtos
{
    public class SanPhamHotDto
    {
        public int ID { get; set; }
        public int IDCauHinh { get; set; }
        public int IDDanhMuc { get; set; }
        public int IDSeller { get; set; }
        public string Mota { get; set; }
        public int? ThoiGianBH { get; set; }
        public int? SLXem { get; set; }
        public string Ten { get; set; }
        public string TenKhac { get; set; }
        public string NoiDung { get; set; }
        public string Hinh { get; set; }
        public string HinhCT { get; set; }
        public bool? TinhTrangHang { get; set; }
        public CauHinh CauHinh { get; set; }
        public PhanLoaiSPCommonViewDto PhanLoaiSP { get; set; }
    }
}
