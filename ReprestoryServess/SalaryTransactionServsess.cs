using DataAcess.layes;
using HR.ViewModel;

using Intersoft.Crosslight.Mobile;

using IREprestory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprestoryServess
{
    public class SalaryTransactionServsess : PaginationHelper<SalaryTransactionVM>, ISalaryTransaction
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public SalaryTransactionServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(SalaryTransactionVM entity)
        {// Determine the date range for the current month
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        //Example: Retrieve employees whose employment started before or on the first day of the month
        //     and ended after or on the last day of the month
         



            var model = SalaryTransactionVM.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.SalaryTransactions.Update(model);
                var month = _Context.EmployeeHistories.Select(e => e.Month).FirstOrDefault();                  
              

                _Context.SaveChanges();


            }
            else
            {


                _Context.SalaryTransactions.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<SalaryTransactionVM> GetAll()
        {
            var model= _Context.SalaryTransactions.Include(p => p.Employee).Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new SalaryTransactionVM
            {
                EmployeeName = _user.Users.Where(m => m.Id == p.EmployeeId).Select(p => p.UserName).FirstOrDefault(),
                Amount = p.Amount,
                isDeleted = p.IsDeleted,
                EmployeeId = p.EmployeeId,
                TransactionDate = p.TransactionDate,
                Reason = p.Reason,
                Id = p.Id,
                transactionTyp = p.transactionTyp,

            }).ToList();

            return model;
        }

        public SalaryTransactionVM GetById(int id)
        {
            var model =
                _Context.SalaryTransactions.Where(p=>p.Id==id).Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new SalaryTransactionVM
                {
                    EmployeeName = _user.Users.Where(m => m.Id == p.EmployeeId).Select(p => p.UserName).FirstOrDefault(),

                    Amount = p.Amount,
                isDeleted = p.IsDeleted,
                EmployeeId = p.EmployeeId,
                TransactionDate = p.TransactionDate,
                Reason = p.Reason,
                Id = p.Id,
                transactionTyp = p.transactionTyp,

            }).FirstOrDefault();

            return model;
        }


        public IEnumerable< SalaryTransactionVM >GetByEmployeeId(string id)
        {
            var model =
                _Context.SalaryTransactions.Where(p => p.EmployeeId == id).Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new SalaryTransactionVM
                {
                    EmployeeName = _user.Users.Where(m => m.Id == p.EmployeeId).Select(p => p.UserName).FirstOrDefault(),

                    Amount = p.Amount,
                    isDeleted = p.IsDeleted,
                    EmployeeId = p.EmployeeId,
                    TransactionDate = p.TransactionDate,
                    Reason = p.Reason,
                    Id = p.Id,
                    transactionTyp = p.transactionTyp,

                }).ToList();

            return model;
        }
















        public bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
