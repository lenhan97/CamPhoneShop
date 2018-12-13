using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuongMaiDienTuAPI.Interfaces;
namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class PageQuery : IPaging, ISorting
    {
        public string TenPage { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "IdPage";
        public string Order { get; set; } = "desc";
    }
}
