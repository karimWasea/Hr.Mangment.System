 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IUnitOfWork : IDisposable

    { IWorkScheduleCurentWeekDay workScheduleCurentWeekDay {  get; }
        IVaction Vaction { get; }
        IEmployeeHistory EmployeeHistory { get; }
        ISalaryTransaction SalaryTransaction { get; }   
        IDeparment Deparment {  get; }    
        Iemployee Employee { get;  }
        ITimeShift timeShift { get; }
         ITrining Trining { get; }
         IDevice Device { get; }
        IEmployeeWorkScheduleCurentWeekDay  employeeWorkScheduleCurentWeek { get; }
    }

    
}
