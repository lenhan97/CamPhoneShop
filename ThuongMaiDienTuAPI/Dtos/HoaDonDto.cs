using System;
using System.Collections.Generic;
namespace ThuongMaiDienTuAPI.Dtos
{
    public class HoaDonDto
    {
        public int? IDUser { get; set; }
        public int IDSeller { get; set; }
        public DateTime Ngay { get; set; }
        public string DiaChiKH { get; set; }
        public string GhiChu { get; set; }
        public string TenKH { get; set; }
        public string Mail { get; set; }
        public string SDT { get; set; }
        public string PhuongThucTT { get; set; }
        public string TinhTrangTT { get; set; }
        public double TongTien { get; set; }
        public ICollection<ChiTietHDDto> ChiTietHD { get; set; } = new HashSet<ChiTietHDDto>();
    }
}
