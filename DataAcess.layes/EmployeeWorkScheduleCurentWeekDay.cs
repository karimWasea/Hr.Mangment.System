using SystemEnums;

namespace DataAcess.layes
{
    public class EmployeeWorkScheduleCurentWeekDay : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? EmployeeId { get; set; }
        public Applicaionuser Employee { get; set; }

        public int TimeShiftId { get; set; }
        public WorkScheduleCurentWeekDay Training { get; set; }
    }
}