using System;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class HoaDonQuery : IPaging, ISorting
    {
        public string TenKH { get; set; } = null;
        public string Mail { get; set; } = null;
        public string SDT { get; set; } = null;
        public string PhuongThucTT { get; set; } = null;
        public string TinhTrangTT { get; set; } = null;
        public int? IDUser { get; set; } = null;
        public int? IDSeller { get; set; } = null;
        public bool? TrangThai { get; set; } = null;
        public DateTime? FromDate { get; set; } = null;
        public DateTime? ToDate { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "Ngay";
        public string Order { get; set; } = "desc";
    }
}
