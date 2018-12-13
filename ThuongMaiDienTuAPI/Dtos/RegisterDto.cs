using System.ComponentModel.DataAnnotations;
namespace ThuongMaiDienTuAPI.Dtos
{
    public class RegisterDto
    {
        public string TenKh { get; set; }
        public string SDT { get; set; }
        public DiaChiDto Diachi { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
    }
}
