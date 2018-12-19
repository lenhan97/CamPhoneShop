using System.ComponentModel.DataAnnotations;
namespace WebMobileMVC.Models
{
    public class RegisterDto
    {
        public string Ten { get; set; }
        public string SDT { get; set; }
        public DiaChiDto Diachi { get; set; }
        [EmailAddress]
        public string Mail { get; set; }
        public string TenDN { get; set; }
        public string MatKhau { get; set; }
    }
}
