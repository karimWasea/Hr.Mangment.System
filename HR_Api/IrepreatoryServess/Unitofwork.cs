using DataAcess.layes;

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

        public Unitofwork(DepatmentServsess_Api deparment , ApplicationDBcontext applicationDBcontext   , DeviceServsess_Api deviceServsess_Api  , VacationServsess_Api vacationServsess_Api , WorkScheduleCurentWeekServsess_Api workScheduleCurentWeekServsess_Api ,  trrningServsess_Api  trrningServsess_Api) {
            Device = deviceServsess_Api;
             _context = applicationDBcontext;
            Deparment = deparment; 
             Vaction = vacationServsess_Api;
             WorkScheduleCurentWeekDay = workScheduleCurentWeekServsess_Api;    
             trining = trrningServsess_Api;
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
