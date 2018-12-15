using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThuongMaiDienTuAPI.Interfaces
{
    public interface IScheduleTaskService
    {
        Task DailyTask();
        Task MonthlyTask();
    }
}
