using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR_Api.Dtos
{
    public class SalaryTransactionTOAdd
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
        //public List<string> transactionTyp
        //{
        //    get
        //    {
        //        return Enum.GetValues(typeof(TransactionSalaryType))
        //                   .Cast<TransactionSalaryType>()
        //                   .Select(type => type.ToString())
        //                   .ToList();
        //    }
        //}
        public TransactionSalaryType transactionTyp { get; set; }
        public static SalaryTransaction ConvertTODTOToObj(SalaryTransactionTOAdd SalaryTransactionTO)
        {

            return new SalaryTransaction
            {



                Amount = SalaryTransactionTO.Amount,
                EmployeeId = SalaryTransactionTO.EmployeeId,
                Reason = SalaryTransactionTO.Reason,
                TransactionDate = SalaryTransactionTO.TransactionDate



            };
        }
    }
    public class SalaryTransactionTO: SalaryTransactionTOAdd
    {
        [Required]

        public int Id { get; set; }

       
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
