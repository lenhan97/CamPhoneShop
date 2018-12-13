using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(128)]
        public string TenDN { get; set; }
        [MaxLength(128)]
        public string Matkhau { get; set; }
        public bool TinhTrang { get; set; }
        [MaxLength(50)]
        public string LoaiUser { get; set; }

        public int IdKhachHang { get; set; }
        public int? IdSeller { get; set; }
    }
}
