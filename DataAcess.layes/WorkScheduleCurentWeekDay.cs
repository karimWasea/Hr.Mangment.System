using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace DataAcess.layes
{

    public class WorkScheduleCurentWeekDay : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public DayOfWeek DayName { get; set; }
        public string ShiftName { get; set; }
        public DateTime? TimestartShift { get; set; }
        public DateTime?  TimeEndshifts { get; set; }
        [NotMapped]
        public string DisplayShift
        {
            get
            {
                return $"{DayName.ToString()} - {ShiftName}";
            }
        }
        public ICollection<EmployeeWorkScheduleCurentWeekDay> EmployeeWorkScheduleCurentWeekDay { get; set; }

        // Navigation property
    }
}