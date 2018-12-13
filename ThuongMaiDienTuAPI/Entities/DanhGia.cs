using System;
using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class DanhGia
    {
        [Key]
        public int ID { get; set; }
        public DateTime Ngay { get; set; }
        [MaxLength(500)]
        public string NoiDung { get; set; }
        public double Danhgia { get; set; }
        [Required]
        public int IDUser { get; set; }
        [Required]
        public int IDSeller { get; set; }
    }
}
