using HR.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IEmployeeWorkScheduleCurentWeekDay : IRepository<EmployeeWorkScheduleCurentWeekDayVm> , IPaginationHelper<EmployeeWorkScheduleCurentWeekDayVm>
    {
        IEnumerable<EmployeeWorkScheduleCurentWeekDayVm> GetAllShiftByemployeeId(string id);
    }
}
