using SystemEnums;

namespace DataAcess.layes
{
    public class Vacation : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string EmployeeId { get; set; }
        public Applicaionuser Employee { get; set; }
    }
}