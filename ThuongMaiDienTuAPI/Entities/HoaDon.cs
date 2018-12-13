using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class HoaDon
    {
        public HoaDon()
        {
            ChiTietHD = new HashSet<ChiTietHD>();
        }
        public HoaDon(HoaDon hoaDon)
        {
            Ngay = hoaDon.Ngay;
            TrangThai = hoaDon.TrangThai;
            IDUser = hoaDon.IDUser;
            DiaChiKH = hoaDon.DiaChiKH;
            GhiChu = hoaDon.GhiChu;
            TenKH = hoaDon.TenKH;
            Mail = hoaDon.Mail;
            SDT = hoaDon.SDT;
            PhuongThucTT = hoaDon.PhuongThucTT;
            TinhTrangTT = hoaDon.TinhTrangTT;
            ChiTietHD = new HashSet<ChiTietHD>();
        }

        [Key]
        public int ID { get; set;  }
        public DateTime Ngay { get; set; }
        public double TongTien { get; set; }
        public bool TrangThai { get; set; }

        public int IDUser { get; set; }

        public string DiaChiKH { get; set; }
        [MaxLength(500)]
        public string GhiChu { get; set; }
        [MaxLength(128)]
        public string TenKH { get; set; }
        public int IDSeller { get; set; }
        //DiaChiKH? & DiaChi string?
        [MaxLength(128)]
        [EmailAddress]
        public string Mail { get; set; }
        [MaxLength(128)]
        [Phone]
        public string SDT { get; set; }
        [MaxLength(50)]
        public string PhuongThucTT { get; set; }
        [MaxLength(128)]
        public string TinhTrangTT { get; set; }
       
        public ICollection<ChiTietHD> ChiTietHD { get; set; }
    }
}
