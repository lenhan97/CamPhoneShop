using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Entities
{
    public class KhachHang
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(128)]
        public string Ten { get; set; }
        [MaxLength(50)]
        [Phone]
        public string SDT { get; set; }

        public int? IDDiaChi { get; set; }

        [MaxLength(128)]
        [EmailAddress]
        public string Mail { get; set; }
        public double DanhGia { get; set; }
        public int Diem { get; set; }

        public DiaChi DiaChi { get; set; }
    }
}
