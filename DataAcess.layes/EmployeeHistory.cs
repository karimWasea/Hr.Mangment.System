using SystemEnums;

namespace DataAcess.layes
{
    public class EmployeeHistory : BaseEntity
    {

        public decimal? TotalSalary { get; set; }
        public DateTime Month { get; set; } = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day);
        public Applicaionuser Employee { get; set; }
        public string EmployeeId { get; set; }
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

    }
}