﻿using ThuongMaiDienTuAPI.Interfaces;

namespace ThuongMaiDienTuAPI.Dtos.Queries
{
    public class GoiDichVuQuery:IPaging,ISorting
    {
        public int? ID { get; set; } = null;
        public string Ten { get; set; } = null;
        public bool? TinhTrang { get; set; } = null;

        public int PageSize { get; set; } = 20;
        public int Page { get; set; } = 1;
        public string SortBy { get; set; } = "Id";
        public string Order { get; set; } = "asc";
    }
}
