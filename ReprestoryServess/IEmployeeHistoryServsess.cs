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

using SystemEnums;

namespace ReprestoryServess
{
    public class EmployeeHistoryServsess : PaginationHelper<EmployeeHistoryvm>, IEmployeeHistory
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public EmployeeHistoryServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(EmployeeHistoryvm entity)
        {// Determine the date range for the current month
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        //Example: Retrieve employees whose employment started before or on the first day of the month
        //     and ended after or on the last day of the month
         



            var model = EmployeeHistoryvm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.EmployeeHistories.Update(model);
                var month = _Context.EmployeeHistories.Select(e => e.Month).FirstOrDefault();                  
              

                _Context.SaveChanges();


            }
            else
            {


                _Context.EmployeeHistories.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<EmployeeHistoryvm> GetAll()
        {
            var model= _Context.EmployeeHistories.Include(p => p.Employee).Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeHistoryvm
            {
            TotalSalary = p.TotalSalary,
                 Month = p.Month,
                     EmployeeId = p.EmployeeId,
                         Id = p.Id
                             
            }).ToList();

            return model;
        }

        public EmployeeHistoryvm GetById(int id)
        {
            var model =
                _Context.EmployeeHistories.Where(p=>p.Id==id).Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeHistoryvm
                {

                    TotalSalary = p.TotalSalary,
                    Month = p.Month,
                    EmployeeId = p.EmployeeId,
                    Id = p.Id

                }).FirstOrDefault();

            return model;
        }


        //public IEnumerable< SalaryTransactionVM >GetByEmployeeId(string id)
        //{
        //    var model =
        //        _Context.EmployeeHistories.Where(p => p.EmployeeId == id).Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new SalaryTransactionVM
        //        {
        //            EmployeeName = _user.Users.Where(m => m.Id == p.EmployeeId).Select(p => p.UserName).FirstOrDefault(),



        //        }).ToList();

        //    return model;
        //}




        public double calcaksalary(string employeeid   ,DateTime Trantationdatime)

        {
            DateTime curentMonth = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day);

            EmployeeHistory histoty = new EmployeeHistory();  
            var totalsalary = _user.Users.Where(p => p.Id == employeeid).Select(p => p.Salary).FirstOrDefault();
            histoty.EmployeeId = employeeid;
            histoty.Month = curentMonth;
            histoty.TotalSalary = (decimal?)totalsalary;
_Context.EmployeeHistories.Add(histoty);

        DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
            var histotyemployee= _Context.SalaryTransactions.Where(p => p.EmployeeId == employeeid).FirstOrDefault();
         
                if (histotyemployee.EmployeeId == employeeid && histotyemployee.transactionTyp == TransactionSalaryType.Bonus && Trantationdatime >= firstDayOfMonth &&
           Trantationdatime <= lastDayOfMonth)
                {


                    return (double)(totalsalary += histotyemployee.Amount);


                }
                else if(histotyemployee.EmployeeId == employeeid && histotyemployee.transactionTyp == TransactionSalaryType.debt || histotyemployee.transactionTyp == TransactionSalaryType.Deduction && histotyemployee.TransactionDate >= firstDayOfMonth &&
            histotyemployee.TransactionDate <= lastDayOfMonth)
                {
                    return (double)(totalsalary -= histotyemployee.Amount);
                }




                    






            
            
                return (double)totalsalary;


          









        }












        public bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
