using SystemEnums;

namespace DataAcess.layes
{

    public class WorkScheduleCurentWeekDay : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public DayOfWeek DayName { get; set; }

        public DateTime? Date { get; set; }
        public ShiftStuTework shiftStuTework { get; set; }
        public string EmployeeId { get; set; }
        public Applicaionuser Employee { get; set; }

        // Navigation property
    }
}