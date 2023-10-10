using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR.ViewModel
{
    public class SalaryTransactionVM : BaseViewModel
    {
        public int Id { get; set; }
        public IsDeleted isDeleted { get; set; }
        [Required(ErrorMessage = "  is required")]

        public string? EmployeeId { get; set; }
        [Required(ErrorMessage = "  is required")]

        public DateTime? TransactionDate { get; set; }
        [Required(ErrorMessage = "  is required")]

        public string Reason { get; set; }
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "  is required")]

        public double? Amount { get; set; }
        [Required(ErrorMessage = "  is required")]

        public TransactionSalaryType transactionTyp { get; set; }

        public IEnumerable<SelectListItem> EmployeeAll { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> ALLtransactionTyps { get; set; } = Enumerable.Empty<SelectListItem>();

        public static SalaryTransaction CanconvertViewmodel(SalaryTransactionVM entity)
        {
            var dept = new SalaryTransaction() {
             
             Amount = (double)entity.Amount,
                 IsDeleted=entity.isDeleted,
                  EmployeeId = entity.EmployeeId,   
                  TransactionDate = (DateTime)entity.TransactionDate, 
                  Reason = entity.Reason,   
                      Id    =   entity.Id,
                      transactionTyp = entity.transactionTyp,
            
            };


            return dept;
        }
    }
}