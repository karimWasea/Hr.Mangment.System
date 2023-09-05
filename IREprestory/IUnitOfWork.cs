using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IUnitOfWork

    {
        IVaction Vaction { get; }
        IEmployeeHistory EmployeeHistory { get; }
        ISalaryTransaction SalaryTransaction { get; }   
        IDeparment Deparment {  get; }    
        Iemployee Employee { get;  }
        ITimeShift timeShift { get; }
    }
}
