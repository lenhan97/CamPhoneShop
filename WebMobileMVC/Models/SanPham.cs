using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace WebMobileMVC.Models
{
    public class SanPham
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Ten { get; set; }
        [Required]
        [MaxLength(256)]
        public string TenKhac { get; set; }

        public int? IDCauHinh { get; set; }
        public int IDDanhMuc { get; set; }
        public int IDSeller { get; set; }

        public int SLXem { get; set; }
        [MaxLength(500)]
        public string Mota { get; set; }
        public string NoiDung { get; set; }
        [MaxLength(256)]
        public string Hinh { get; set; }
        [DataType("xml")]
        public string HinhCT { get; set; }
        public int ThoiGianBH { get; set; }

        public DateTime NgayTao { get; set; }
        public bool TinhTrang { get; set; }
        public bool? TinhTrangHang { get; set; }

        public CauHinh CauHinh { get; set; }
        public List<PhanLoaiSP> PhanLoaiSP { get; set; }
        public int? IDKhuyenMai { get; set; }
    }
}
