namespace ThuongMaiDienTuAPI.Dtos
{
    public class PhanLoaiSPCommonViewDto
    {
        public int ID { get; set; }
        public int IdSanPham { get; set; }
        public int SoLuong { get; set; }
        public int? GiaKM { get; set; }
        public int GiaBan { get; set; }
        public string Mau { get; set; }
        public int? SLMua { get; set; }
    }
}
