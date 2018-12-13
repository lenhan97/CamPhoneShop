using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IPaging
    {
        int PageSize { get; set; }
        int Page { get; set; }
    }
}
