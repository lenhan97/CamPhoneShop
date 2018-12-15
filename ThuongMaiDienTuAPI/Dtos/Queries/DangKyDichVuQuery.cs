using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class DangKyDichVuQuery : ISorting, IPaging
    {
        public int? Id { get; set; } = null;
        public int? IdSeller { get; set; } = null;
        public int? IdGoiDichVu { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "ThoiGianDangKy";
        public string Order { get; set; } = "desc";
    }
}
