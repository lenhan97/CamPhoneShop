using System.ComponentModel.DataAnnotations;

namespace WebMobileMVC.Models
{
    public class GoiDichVu
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(256)]
        [Required]
        public string Ten { get; set; }
        public double Gia { get; set; }
        [MaxLength(128)]
        public string ThoiGian { get; set; }
        public bool TinhTrang { get; set; }
    }
}
