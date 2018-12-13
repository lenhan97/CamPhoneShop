using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class Page
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(256)]
        [Required]
        public string Ten { get; set; }
        [MaxLength(256)]
        [Required]
        public string TenKhac { get; set; }
        [Required]
        public string NoiDung { get; set; }
        public bool TinhTrang { get; set; }
    }
}
