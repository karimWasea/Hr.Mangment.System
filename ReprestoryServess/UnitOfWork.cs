

namespace ReprestoryServess
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly ApplicationDBcontext  _context;

        public UnitOfWork(
ApplicationDBcontext context ,EmployeeServsss employeeServsss , DepatmentServsess DepatmentServsess, SalaryTransactionServsess salaryTransactionServsess , TimeShiftServsss shiftServsess , VactionServsess vactionServsess , TriningServsess triningServsess , DeviceServsess deviceServsess , WorkScheduleCurentWeekDayServsess workScheduleCurentWeekDayServsess , EmployeeWorkScheduleCurentWeekDayServsess  employeeWorkScheduleCurentWeekDayServsess
            , EmployeeDeviceServsess employeeDeviceServsess , EmployeeTriningServsess employeeTriningServsess , RoleService roleService

        )

        {
            roleS = roleService;


            Trining = triningServsess
                ;
            Device = deviceServsess;
            Vaction = vactionServsess;
            timeShift = shiftServsess;
            SalaryTransaction =salaryTransactionServsess;
            Deparment = DepatmentServsess;
            Employee = employeeServsss;
            _context = context;
                 workScheduleCurentWeekDay = workScheduleCurentWeekDayServsess;
            employeeWorkScheduleCurentWeek = employeeWorkScheduleCurentWeekDayServsess;
            employeetrining = employeeTriningServsess;
            employeeDevice = employeeDeviceServsess;



        }

        #region Implement the Dispose method to release resources
        private bool disposed = false;

       public Iemployee Employee { get; }
        public IDeparment Deparment { get; }
        public ISalaryTransaction SalaryTransaction { get; }
        public IEmployeeHistory EmployeeHistory { get; }
        public ITimeShift timeShift { get; }
        public IVaction Vaction { get; }
        public ITrining Trining { get; }
        public IDevice Device { get; }
        public IWorkScheduleCurentWeekDay workScheduleCurentWeekDay { get; }
        public IEmployeeWorkScheduleCurentWeekDay employeeWorkScheduleCurentWeek { get; }
        public IEmployeeDevice employeeDevice { get; }
        public IEmployeetrining employeetrining { get; }
        public IRoleS roleS { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }




        // Implement the finalizer to release unmanaged resources
        ~UnitOfWork()
        {
            Dispose(false);
        }
        #endregion

















    }
}
