using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using System.Runtime.InteropServices;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public class  TransactionsalaryServess_Api : PaginationHelper<SalaryTransactionTO>, ISalarytransaction_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        private SalaryclackServesses _SalaryclackServesses;
        public TransactionsalaryServess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user, SalaryclackServesses SalaryclackServesses)
        {
            _SalaryclackServesses = SalaryclackServesses;
            _user = user;
            _Context = db;
        }
        public SalaryTransaction Add(SalaryTransactionTOAdd entity)
        {
            // Determine the date range for the current month
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            //Example: Retrieve employees whose employment started before or on the first day of the month
            //     and ended after or on the last day of the month
            var model = SalaryTransactionTOAdd.ConvertTODTOToObj(entity);
            var entityadd = _Context.SalaryTransactions.Add(model);
            _SalaryclackServesses.CalculateSalary(entityadd.Entity.EmployeeId, (decimal)entityadd.Entity.Amount, entityadd.Entity.TransactionDate);


            _Context.SaveChanges();
            return entityadd.Entity;
        } 
        
        
        public SalaryTransaction Update(SalaryTransactionTO entity)
        {
            // Determine the date range for the current month
            DateTime today = DateTime.Today;
            DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            //Example: Retrieve employees whose employment started before or on the first day of the month
            //     and ended after or on the last day of the month
            var model = SalaryTransactionTO.ConvertTODTOToObj(entity);
            var entityadd = _Context.SalaryTransactions.Update(model);
            _SalaryclackServesses.CalculateSalary(entityadd.Entity.EmployeeId, (decimal)entityadd.Entity.Amount, entityadd.Entity.TransactionDate);


            _Context.SaveChanges();
            return entityadd.Entity;
        }

        //public SalaryTransactionTO Save(SalaryTransactionTO entity)
        //{// Determine the date range for the current month
        //    DateTime today = DateTime.Today;
        //    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
        //    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

        //    //Example: Retrieve employees whose employment started before or on the first day of the month
        //    //     and ended after or on the last day of the month




        //    var model = SalaryTransactionTO.ConvertTODTOToObj(entity);

        //    if (entity.Id > 0)
        //    {
        //       var entityadd = _Context.SalaryTransactions.Update(model);

        //        _Context.SaveChanges();
        //        _SalaryclackServesses.CalculateSalary(entityadd.Entity.EmployeeId, (decimal)entityadd.Entity.Amount, entityadd.Entity.TransactionDate);


        //    }
        //    else
        //    {


        //       var entityadd = _Context.SalaryTransactions.Add(model);

        //        _Context.SaveChanges();
        //        _SalaryclackServesses.CalculateSalary(entityadd.Entity.EmployeeId, (decimal)entityadd.Entity.Amount, entityadd.Entity.TransactionDate);

        //    }
        //    return entity;
        //}







        public bool Delete(int id)
        {



            var deletedmodel = GetById(id);

            Update(deletedmodel);
            _SalaryclackServesses.CalculateSalary(deletedmodel.EmployeeId, (decimal)deletedmodel.Amount, (DateTime)deletedmodel.TransactionDate);
             _Context.Remove(deletedmodel);
            _Context.SaveChanges( );
            return true;



        }

        public IEnumerable<SalaryTransactionTO> GetAll()
        {
            var model = _Context.SalaryTransactions.Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new SalaryTransactionTO
            {
           
                Amount = p.Amount,
                EmployeeId = p.EmployeeId,
                TransactionDate = p.TransactionDate,
                Reason = p.Reason,
                Id = p.Id,
                transactionTyp = p.transactionTyp,

            }).ToList();

            return model;
        }

        public SalaryTransactionTO GetById(int id)
        {
            var model =
                _Context.SalaryTransactions.Where(p => p.Id == id).Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new SalaryTransactionTO
                {
                   

                    Amount = p.Amount,
                    EmployeeId = p.EmployeeId,
                    TransactionDate = p.TransactionDate,
                    Reason = p.Reason,
                    Id = p.Id,
                    transactionTyp = p.transactionTyp,

                }).FirstOrDefault();

            return model;
        }
        public SalaryTransactionTO GEtByemployeeId(string id)
        {
            var model =
                _Context.SalaryTransactions.Include(p => p.Employee).Select(p => new SalaryTransactionTO
                {
                   

                    Amount = p.Amount,
                    EmployeeId = p.EmployeeId,
                    TransactionDate = p.TransactionDate,
                    Reason = p.Reason,
                    Id = p.Id,
                    transactionTyp = p.transactionTyp,

                }).FirstOrDefault();

            return model;
        }


        public IEnumerable<SalaryTransactionTO> GetByEmployeeIdALLtrantionforemployee(string id)
        {
            var model =
                _Context.SalaryTransactions.Where(p => p.EmployeeId == id).Include(p => p.Employee).Select(p => new SalaryTransactionTO
                {
                

                    Amount = p.Amount,
                    EmployeeId = p.EmployeeId,
                    TransactionDate = p.TransactionDate,
                    Reason = p.Reason,
                    Id = p.Id,
                    transactionTyp = p.transactionTyp,

                }).ToList();

            return model;
        }

















        public IEnumerable<SalaryTransactionTO> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.SalaryTransactions
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.TransactionDate.ToString().Contains(searchTerm) ||p.Reason.Contains(searchTerm))
                .Select(p => new SalaryTransactionTO
                {
                    Amount = p.Amount,
                    EmployeeId = p.EmployeeId,
                    TransactionDate = p.TransactionDate,
                    Reason = p.Reason,
                    Id = p.Id,
                    transactionTyp = p.transactionTyp,

                })
                .ToList();
        }




        //public IEnumerable<DepartmintDTO> Search(string searchTerm)
        //{
        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        // If searchTerm is empty, return all departments
        //        var allDepartments = _Context.Departments
        //            .Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Include(t => t.Employees)
        //            .Select(p => new DepartmintDTO
        //            {
        //                Id = p.Id,
        //                Name = p.DepartmentName,
        //                ManagerId = p.ManagerId,
        //                mangerName = _user.Users
        //                    .Where(m => m.Id == p.ManagerId)
        //                    .Select(m => m.UserName)
        //                    .FirstOrDefault(),
        //            })
        //            .ToList();

        //        return allDepartments;
        //    }

        //else
        //{
        //  //  If searchTerm is not empty, perform the search
        //           var departments = _Context.Departments
        //               .Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted &&
        //                           (p.DepartmentName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        //                            _user.Users.Any(u => u.Id == p.ManagerId || u.UserName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
        //                            || string.IsNullOrWhiteSpace(searchTerm)

        //                            )
        //               .Select(p => new DepartmintDTO
        //               {
        //                   Id = p.Id,
        //                   Name = p.DepartmentName,
        //                   ManagerId = p.ManagerId,
        //                   mangerName = _user.Users
        //                       .Where(m => m.Id == p.ManagerId)
        //                       .Select(m => m.UserName)
        //                       .FirstOrDefault(),
        //               })
        //               .ToList();

        //    return departments;
        //    }
        //}



    }
}
