using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using SystemEnums;

namespace DataAcess.layes
{
     public class Applicaionuser : IdentityUser
    {
        public string? ImgUrl { get; set; } = string.Empty;
    
        public DateTime? BirthDate { get; set; }
        public string? Adress { get; set; }
= string.Empty;
        public double? Salary { get; set; } = 1000.0f;
        public Gender Gender { get; set; }
        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public double? Bouns { get; set; }
        public string? JobTitle { get; set; }
        public string? ContructUrl { get; set; }
        public DateTime? HirangDate { get; set; }
        [JsonIgnore]

        public ICollection<TimeShift> TimeShifts { get; set; }
        [JsonIgnore]

        public ICollection<EmployeeHistory> EmployeeHistories { get; set; }
        [JsonIgnore]

        public ICollection<EmployeeWorkScheduleCurentWeekDay> EmployeeWorkScheduleCurentWeekDay { get; set; }
        [JsonIgnore]

        public ICollection<EmployeeDevice> EmployeeDevices { get; set; }
        [JsonIgnore]
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        [JsonIgnore]
        public ICollection<Vacation> Vacations { get; set; }

    }
}