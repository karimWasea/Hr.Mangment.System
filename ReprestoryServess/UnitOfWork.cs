﻿using DataAcess.layes;

using IREprestory;

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprestoryServess
{
    public class UnitOfWork : IUnitOfWork
    {

        public readonly ApplicationDBcontext  _context;

        public UnitOfWork(
ApplicationDBcontext context ,EmployeeServsss employeeServsss , DepatmentServsess DepatmentServsess
            )

        {
            Deparment = DepatmentServsess;
            Employee = employeeServsss;
            _context = context;
           
        }

        #region Implement the Dispose method to release resources
        private bool disposed = false;

       public Iemployee Employee { get; }
        public IDeparment Deparment { get; }

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
