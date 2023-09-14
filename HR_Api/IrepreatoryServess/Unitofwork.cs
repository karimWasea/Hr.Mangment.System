using DataAcess.layes;

using HR_Api.Irepreatory;

namespace HR_Api.IrepreatoryServess
{
    public class Unitofwork :IunitofWork
    {
        public readonly ApplicationDBcontext _context;
        private bool disposed = false;

        public IDeparment_Api Deparment { get; }

        public Unitofwork(DepatmentServsess_Api deparment , ApplicationDBcontext applicationDBcontext   ) {
             _context = applicationDBcontext;
            Deparment = deparment;  
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
