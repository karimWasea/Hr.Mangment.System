using DataAcess.layes;

using HR_Api.Utellites;

using SystemEnums;

namespace HR_Api.Dtos
{
    public class SalaryTransactionTO : BaseDTO
    {

        public string EmployeeId { get; set; }
        public DateTime TransactionDate { get; set; }
        public string? Reason { get; set; }
        public double Amount { get; set; }
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
