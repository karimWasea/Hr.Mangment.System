namespace DataAcess.layes
{
    public class EmployeeHistory : BaseEntity
    {

        public decimal? TotalSalary { get; set; }
        public string? MamthName { get; set; }
        public Applicaionuser Employee { get; set; }
        public string EmployeeId { get; set; }

    }
}