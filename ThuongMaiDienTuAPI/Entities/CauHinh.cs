using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class CauHinh
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(128)]
        public string ThuongHieu { get; set; }
        [MaxLength(128)]
        [Required]
        public string BoNho { get; set; }
        [MaxLength(128)]
        [Required]
        public string Mang { get; set; }
        [MaxLength(128)]
        [Required]
        public string Sim { get; set; }
        [MaxLength(128)]
        [Required]
        public string ChongThamNuoc { get; set; }
        [MaxLength(128)]
        [Required]
        public string KTManHinh { get; set; }
        [MaxLength(128)]
        [Required]
        public string HeDieuHanh { get; set; }
        [MaxLength(128)]
        [Required]
        public string Ram { get; set; }
        [MaxLength(128)]
        [Required]
        public string CMRTruoc { get; set; }
        [MaxLength(128)]
        [Required]
        public string CMRSau { get; set; }
        [MaxLength(128)]
        [Required]
        public string GPS { get; set; }
        [MaxLength(128)]
        [Required]
        public string Bluetooth { get; set; }
        [MaxLength(128)]
        [Required]
        public string Pin { get; set; }
    }
}
