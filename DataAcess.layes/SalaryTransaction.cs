using SystemEnums;

namespace DataAcess.layes
{
    public class SalaryTransaction : BaseEntity
    {
        public string? EmployeeId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? Reason { get; set; }
        public decimal? Amount { get; set; }
        public TransactionSalaryType transactionTyp { get; set; }
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        // Navigation property
        public Applicaionuser Employee { get; set; }
    }

}