using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace DataAcess.layes
{  public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int  Id { get; set; }  }







    






    public class ApplicationDBcontext : IdentityDbContext<Applicaionuser>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        { }

        //public DbSet<Employee> Employees { get; set; }
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