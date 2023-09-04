using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace HR.ViewModel
{
    public class SalaryTransactionVM : BaseViewModel
    {
        public string? EmployeeId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string Reason { get; set; }
        public string EmployeeName { get; set; }
        public decimal? Amount { get; set; }
        public TransactionSalaryType transactionTyp { get; set; }

        public IEnumerable<SelectListItem> EmployeeAll { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLtransactionTyps { get; set; } = Enumerable.Empty<SelectListItem>();

        public static SalaryTransaction CanconvertViewmodel(SalaryTransactionVM entity)
        {
            var dept = new SalaryTransaction() {
             
             Amount = entity.Amount,
                 IsDeleted=entity.isDeleted,
                  EmployeeId = entity.EmployeeId,   
                  TransactionDate = entity.TransactionDate, 
                  Reason = entity.Reason,   
                      Id    =   entity.Id,
                      transactionTyp = entity.transactionTyp,
            
            };


            return dept;
        }
    }
}