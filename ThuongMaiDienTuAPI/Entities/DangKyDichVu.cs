using System;
using System.ComponentModel.DataAnnotations;

namespace ThuongMaiDienTuAPI.Entities
{
    public class DangKyDichVu
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int IDSeller { get; set; }
        [Required]
        public int IDGoiDichVu { get; set; }
        public DateTime ThoiGianDangKy { get; set; }
    }
}
