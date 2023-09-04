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
        public TimeSpan? StartingTime { get; set; }
        public TimeSpan? EndingTime { get; set; }
        public DateTime? dateTime { get; set; }
        public Applicaionuser Employee { get; set; }

    }
}