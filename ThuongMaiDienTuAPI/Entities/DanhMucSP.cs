using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class DanhMucSP
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(256)]
        public string Ten { get; set; }
        [Required]
        [MaxLength(256)]
        public string TenKhac { get; set; }
        public bool TinhTrang { get; set; }
        [MaxLength(256)]
        public string Hinh { get; set; }
    }
}
