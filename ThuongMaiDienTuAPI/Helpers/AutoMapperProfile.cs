using AutoMapper;
using ThuongMaiDienTuAPI.Dtos;
using ThuongMaiDienTuAPI.Entities;
namespace ThuongMaiDienTuAPI.Helpers
{
    /// <summary>
    /// Mapping Dtos classes and Entities classes
    /// </summary>
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User,UserDto>();
            CreateMap<UserDto,User>();
            CreateMap<DanhMucSP, DanhMucSPDto>();
            CreateMap<DanhMucSPDto, DanhMucSP>();
            CreateMap<KhuyenMai, KhuyenMaiDto>();
            CreateMap<KhuyenMaiDto, KhuyenMai>();
            CreateMap<QuangCao, QuangCaoDto>();
            CreateMap<QuangCaoDto, QuangCao>();
            CreateMap<DiaChi, DiaChiDto>();
            CreateMap<DiaChiDto, DiaChi>();
            CreateMap<RegisterDto, User>();
            CreateMap<RegisterDto, KhachHang>();
            CreateMap<SellerDto, Seller>();
            CreateMap<DanhGiaDto, DanhGia>();
            CreateMap<PhanLoaiSP, PhanLoaiSPCommonViewDto>();
            CreateMap<SanPham, SanPhamCommonViewDto>();
            CreateMap<HoaDonDto, HoaDon>();
            CreateMap<ChiTietHDDto, ChiTietHD>();
        }
    }
}
