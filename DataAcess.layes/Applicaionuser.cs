using Microsoft.AspNetCore.Identity;

using SystemEnums;

namespace DataAcess.layes
{
  /    public class Applicaionuser : IdentityUser
    {
        public string? ImgUrl { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }
        public string? Adress { get; set; }
= string.Empty;
        public double? Salary { get; set; }
        public Gender Gender { get; set; }
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public double? Bouns { get; set; }
        public string? JobTitle { get; set; }
        public string? ContructUrl { get; set; }
        public DateTime? HirangDate { get; set; }

        public ICollection<TimeShift> TimeShifts { get; set; }
        public ICollection<EmployeeHistory> EmployeeHistories { get; set; }
        public ICollection<WorkScheduleCurentWeekDay> WorkScheduleCurentWeekDay { get; set; }
        public ICollection<EmployeeDevice> EmployeeDevices { get; set; }
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        public ICollection<Vacation> Vacations { get; set; }

    }
}