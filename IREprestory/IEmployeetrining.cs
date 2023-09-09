using HR.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IEmployeetrining : IRepository<EmployeeTrininTVm> , IPaginationHelper<EmployeeTrininTVm>
    {
        IEnumerable<EmployeeTrininTVm> GetAllShiftByemployeeId(string id);
    }
}
