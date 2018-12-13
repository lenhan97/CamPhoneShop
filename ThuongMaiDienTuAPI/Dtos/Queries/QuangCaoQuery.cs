using System;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class QuangCaoQuery : IPaging, ISorting
    {
        public string TenDoiTac { get; set; } = null;
        public string NguoiDaiDien { get; set; } = null;
        public DateTime? NgayBatDau { get; set; } = null;
        public DateTime? NgayKetThuc { get; set; } = null;
        public bool? TinhTrang { get; set; } = null;
        public string LoaiQuangCao { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "NgayDangKy";
        public string Order { get; set; } = "desc";
    }
}
