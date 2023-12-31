﻿using DataAcess.layes;

using HR_Api.Irepreatory;

namespace HR_Api.IrepreatoryServess
{
    public class Unitofwork :IunitofWork
    {
        public readonly ApplicationDBcontext _context;
        private bool disposed = false;

        public IDeparment_Api Deparment { get; }
        public IDevice_Api Device { get; }
        public IWorkScheduleCurentWeekDay_Api WorkScheduleCurentWeekDay { get; }
        public IVaction_Api Vaction { get; }
        public ITrining_Api trining { get; }
        public Iemployee_Api Employee { get; }
        public IDeviceEmpoyee_Api deviceEmpoyee { get; }
        public ISalarytransaction_Api salarytransaction_Api { get; }
        public ITriningEmpoyee_Api TriningEmpoyee { get; }
        public ISystemRole_Api systemRole_Api { get; }

        public Unitofwork(DepatmentServsess_Api deparment , ApplicationDBcontext applicationDBcontext   , DeviceServsess_Api deviceServsess_Api  , VacationServsess_Api vacationServsess_Api , WorkScheduleCurentWeekServsess_Api workScheduleCurentWeekServsess_Api ,  trrningServsess_Api  trrningServsess_Api , EmployeeServess employeeServess , DeviceEmployyServsess_Api  deviceEmployyServsess_Api , TransactionsalaryServess_Api salaryclackServesses, TriningEmpoyeeServsess_Api triningEmpoyeeServsess_Api , IRoleServess roleServessy
   ) {
            Device = deviceServsess_Api;
             _context=  applicationDBcontext;
            Deparment = deparment; 
             Vaction = vacationServsess_Api;
             WorkScheduleCurentWeekDay = workScheduleCurentWeekServsess_Api;    
             trining = trrningServsess_Api;
             Employee = employeeServess;
            deviceEmpoyee = deviceEmployyServsess_Api;
            salarytransaction_Api = salaryclackServesses;
            TriningEmpoyee = triningEmpoyeeServsess_Api;
            systemRole_Api = roleServessy;
        }
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
        ~Unitofwork()
        {
            Dispose(false);
        }

    }
}
