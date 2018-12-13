using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class KhachHangQuery : IPaging, ISorting
    {
        public string TenKh { get; set; } = null;
        public string SDT { get; set; } = null;
        public string Mail { get; set; } = null;
        public int? FromDanhGia { get; set; } = null;
        public int? ToDanhGia { get; set; } = null;
        public int? FromDiem { get; set; } = null;
        public int? ToDiem { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "TenKH";
        public string Order { get; set; } = "asc";
    }
}
