using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface ISorting
    {
        string SortBy { get; set; }
        string Order { get; set; }
    }
}
