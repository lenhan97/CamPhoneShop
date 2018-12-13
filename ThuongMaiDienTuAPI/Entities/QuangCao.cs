using System;
using System.ComponentModel.DataAnnotations;

namespace ThuongMaiDienTuAPI.Entities
{
    public class QuangCao
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string TenDoiTac { get; set; }
        [Required]
        public int IDLoaiQC { get; set; }
        public double GiaThue { get; set; }
        [MaxLength(128)]
        public string NguoiDaiDien { get; set; }
        [MaxLength(128)]
        [Required]
        public string Hinh { get; set; }
        [MaxLength(256)]
        public string URL { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDangKy { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool TinhTrang { get; set; }
    }
}
