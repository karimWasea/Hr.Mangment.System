using Microsoft.Identity.Client;

using SystemEnums;

namespace DataAcess.layes
{

    public class TimeShift : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        public int? HoursPershift { get; set; }
        public ShiftStuTework shiftStuTework { get; set; }

        public string? EmployeeId { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }
    
        public Applicaionuser Employee { get; set; }

    }
}