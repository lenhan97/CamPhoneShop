using System.ComponentModel.DataAnnotations;

namespace WebMobileMVC.Models
{
    public class DiaChi
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(128)]
        [Required]
        public string SoNha { get; set; }
        [MaxLength(128)]
        [Required]
        public string Duong { get; set; }
        [MaxLength(128)]
        [Required]
        public string PhuongXa { get; set; }
        [MaxLength(128)]
        [Required]
        public string QuanHuyen { get; set; }
        [MaxLength(128)]
        [Required]
        public string TinhTP { get; set; }
    }
}
