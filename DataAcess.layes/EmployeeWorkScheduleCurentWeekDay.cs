using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace DataAcess.layes
{
    public class EmployeeWorkScheduleCurentWeekDay : BaseEntity
    {
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? EmployeeId { get; set; }
        public Applicaionuser Employee { get; set; }

        [ForeignKey("WorkScheduleCurentWeekDay")]
        public int? TimeShiftId { get; set; }
        public WorkScheduleCurentWeekDay WorkScheduleCurentWeekDay { get; set; }


    }
}