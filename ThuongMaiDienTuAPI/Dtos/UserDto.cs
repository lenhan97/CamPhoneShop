namespace ThuongMaiDienTuAPI.Dtos
{
    public class UserDto
    {
        public int ID { get; set; }
        public string TenDN { get; set; }
        public bool TrangThai { get; set; }
        public string LoaiUser { get; set; }
        public int IDKhachHang { get; set; }
        public int? IDSeller { get; set; }
    }
}
