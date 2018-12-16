namespace ThuongMaiDienTuAPI.Dtos
{
    public class PhanLoaiSPDto
    {
        public int SoLuong { get; set; }
        public double? GiaKM { get; set; }
        public double GiaBan { get; set; }
        public double GiaGoc { get; set; }
        public string Mau { get; set; }
        public int SLMua { get; set; } = 0;
    }
}
