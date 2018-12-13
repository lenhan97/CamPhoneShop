using System;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class KhuyenMaiQuery : IPaging, ISorting
    {
        public int? IdNguoiTao { get; set; } = null;
        public DateTime? NgayKetThuc { get; set; } = null;
        public DateTime? NgayBatDau { get; set; } = null;

        public int PageSize { get; set; } = 10;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "NgayBatDau";
        public string Order { get; set; } = "desc";
    }
}
