using Microsoft.EntityFrameworkCore;
using ThuongMaiDienTuAPI.Entities;
namespace ThuongMaiDienTuAPI.Helpers
{
    /// <summary>
    /// Connect database map entities
    /// </summary>
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> op) : base(op) { }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Seller> Seller { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<ChiTietHD> ChiTietHD { get; set; }
        public virtual DbSet<DanhGia> DanhGia { get; set; }
        public virtual DbSet<DiaChi> DiaChi { get; set; }
        public virtual DbSet<HoaDon> HoaDon { get; set; }
        //----------------------------------------------------------------------------------
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<ChiTietKhuyenMai> ChiTietKhuyenMai { get; set; }
        public virtual DbSet<DangKyDichVu> DangKyDichVu { get; set; }
        public virtual DbSet<GoiDichVu> GoiDichVu { get; set; }
        public virtual DbSet<QuangCao> QuangCao { get; set; }
        public virtual DbSet<LoaiQuangCao> LoaiQuangCao { get; set; }

        public virtual DbSet<ThongBao> ThongBao { get; set; }
        public virtual DbSet<CauHinh> CauHinh { get; set; }
        public virtual DbSet<PhanLoaiSP> PhanLoaiSP { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<DanhMucSP> DanhMucSP { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<Slide> Slide { get; set; }
        public virtual DbSet<XacNhanMail> XacNhanMail { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChiTietHD>().HasKey(x => new { x.IDHoaDon, x.IDPhanLoaiSP });
            builder.Entity<ChiTietHD>().HasOne<HoaDon>().WithMany(x => x.ChiTietHD).HasForeignKey(x => x.IDHoaDon);


            builder.Entity<DiaChi>().HasOne<KhachHang>().WithOne(x => x.DiaChi).HasForeignKey<KhachHang>(x=>x.IDDiaChi);
            builder.Entity<DiaChi>().HasOne<Seller>().WithOne(x => x.DiaChi).HasForeignKey<Seller>(x=>x.IDDiaChi);

            builder.Entity<CauHinh>().HasOne<SanPham>().WithOne(x => x.CauHinh).HasForeignKey<SanPham>(x=>x.IDCauHinh);
            builder.Entity<PhanLoaiSP>().HasOne<SanPham>().WithMany(x => x.PhanLoaiSP).HasForeignKey(x => x.IDSanPham).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChiTietKhuyenMai>().HasKey(x => new { x.IDKhuyenMai, x.IDSanPham });
            builder.Entity<ChiTietKhuyenMai>().HasOne<KhuyenMai>().WithMany(x => x.ChiTietKM).HasForeignKey(x => x.IDKhuyenMai);
        }
    }
}