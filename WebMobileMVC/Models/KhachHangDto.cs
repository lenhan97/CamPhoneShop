namespace WebMobileMVC.Models
{
    public class KhachHangDto
    {
        public string Ten { get; set; }
        public string SDT { get; set; }
        public int Diem { get; set; }

        public DiaChiDto DiaChi { get; set; }
    }
}
