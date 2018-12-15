using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThuongMaiDienTuAPI.Dtos
{
    public class ChangePasswordUserDto
    {
        public string CurrentPass { get; set; }
        public string NewPass { get; set; }
    }
}
