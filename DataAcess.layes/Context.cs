using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using SystemEnums;

namespace DataAcess.layes
{  public class BaseEntity
    {
        public Guid Id { get; set; }
    }
    public class Applicaionuser : IdentityUser
    {
        public string ? ImgUrl { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; }
        public string ?Adress { get; set; }
= string.Empty;
        public double? Salary { get; set; } 
        public Gender  Gender { get; set; }
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

    }

    public class EmployeeHistory : BaseEntity
    {
       public decimal ? TotalSalary { get; set; }
       public  string?  MamthName { get; set; }
       public  Employee    Employee { get; set; }
       public  string  EmployeeId { get; set; }

    }
        public class SalaryTransaction : BaseEntity
    {
        public  string? EmployeeId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public string? Reason { get; set; }
        public decimal? Amount { get; set; }
        public TransactionSalaryType transactionTyp { get; set; }
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        
        // Navigation property
        public Employee Employee { get; set; }
    }

    public class Employee : Applicaionuser
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        public string? ManagerId { get; set; }
        public Employee Manager { get; set; }
        public double ?Bouns { get; set; }
        public string ?JobTitle { get; set; }
        public string? ContructUrl  { get; set; }
        public DateTime? HirangDate { get; set; }

        public ICollection<TimeShift>  TimeShifts { get; set; }
        public ICollection<EmployeeHistory>  EmployeeHistories { get; set; }
        public ICollection<WorkScheduleCurentWeekDay> WorkScheduleCurentWeekDay { get; set; }
        public ICollection<EmployeeDevice> EmployeeDevices { get; set; }
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        public ICollection<Vacation> Vacations { get; set; }

        // Other properties and methods
    }

    public class TimeShift : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        public int? HoursPershift { get; set; }
        public ShiftStuTework shiftStuTework { get; set; }

        public string ?EmployeeId { get; set; }
        public TimeSpan ?StartingTime { get; set; }
        public TimeSpan? EndingTime { get; set; }
        public DateTime  ? dateTime { get; set; }
        public Employee  Employee { get; set; }

        // Navigation property
    }

    public class WorkScheduleCurentWeekDay : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public  DayOfWeek DayName { get; set; }

        public DateTime ? Date { get; set; }
          public  ShiftStuTework shiftStuTework { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }

        // Navigation property
    }

    

    public class Device : BaseEntity
    {
        public string? DeviceName { get; set; }

        // Navigation property
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public ICollection<EmployeeDevice> EmployeeDevices { get; set; }
    }

    public class EmployeeDevice : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid DeviceId { get; set; }
        public Device Device { get; set; }
    }

    public class Vacation : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public DateTime ? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }

    public class Department : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public Guid DepartmentId { get; set; }
        public string? DepartmentName { get; set; } = string.Empty;
        public string? ManagerId { get; set; }
        public Employee Manager { get; set; }
        // Navigation property
        public ICollection<Employee> Employees { get; set; }
    }

    public class Training : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string? TrainingName { get; set; }

        // Navigation property
        public ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
    }

    public class EmployeeTraining : BaseEntity
    {
        IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;

        public string ? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid TrainingId { get; set; }
        public Training Training { get; set; }
    }

    public class ApplicationDBcontext : IdentityDbContext<Applicaionuser>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryTransaction> SalaryTransactions { get; set; }
        public DbSet<TimeShift> TimeShifts { get; set; }
        public DbSet<WorkScheduleCurentWeekDay>  workScheduleCurentWeeks { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<EmployeeDevice> EmployeeDevices { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }

    }

   
      


   
}