using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR_Api.Dtos
{
    public class SalaryTransactionTO : BaseDTO
    {
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public DateTime TransactionDate { get; set; }
        [Required]
        public string? Reason { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public TransactionSalaryType transactionTyp { get; set; }
        public static SalaryTransaction ConvertTODTOToObj(SalaryTransactionTO SalaryTransactionTO)
        {

            return new SalaryTransaction
            {


                Id = SalaryTransactionTO.Id,
                Amount = SalaryTransactionTO.Amount,
                EmployeeId = SalaryTransactionTO.EmployeeId,
                 Reason = SalaryTransactionTO.Reason,
                  TransactionDate = SalaryTransactionTO.TransactionDate
             


            };   
        }
    
    }
}
