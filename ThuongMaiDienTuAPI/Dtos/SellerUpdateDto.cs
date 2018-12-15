using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThuongMaiDienTuAPI.Dtos
{
    public class SellerUpdateDto
    {
        public string Ten { get; set; }
        public string SDT { get; set; }
        public DiaChiDto DiaChi { get; set; }
    }
}
