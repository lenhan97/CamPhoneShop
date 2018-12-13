using System;
using System.Collections.Generic;

namespace ThuongMaiDienTuAPI.Dtos
{
    public class KhuyenMaiDto
    {
        public string Ten { get; set; }
        public double PhamTramKM { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public ICollection<ChiTietKhuyenMaiDto> ChiTietKM { get; set; } = new HashSet<ChiTietKhuyenMaiDto>();
    }
}
