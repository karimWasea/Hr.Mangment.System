using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace DataAcess.layes
{ public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } }














    public class ApplicationDBcontext : IdentityDbContext<Applicaionuser>
    {
        public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
            : base(options)
        { }

        //public DbSet<Employee> Employees { get; set; }
        public DbSet<SalaryTransaction> SalaryTransactions { get; set; }
        public DbSet<TimeShift> TimeShifts { get; set; }
        public DbSet<WorkScheduleCurentWeekDay> workScheduleCurentWeeks { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<EmployeeDevice> EmployeeDevices { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<EmployeeWorkScheduleCurentWeekDay> EmployeeWorkScheduleCurentWeekDay { get; set; }
        public DbSet<EmployeeTraining> EmployeeTrainings { get; set; }
        public DbSet<EmployeeHistory> EmployeeHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the key for the IdentityUserLogin entity
            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(ul => new { ul.LoginProvider, ul.ProviderKey });

            var userid = Guid.NewGuid().ToString();
           
            var RoleSuperAdminId = Guid.NewGuid().ToString();
            var RoleAdminId = Guid.NewGuid().ToString();
            var RoleUserID = Guid.NewGuid().ToString();
            var hasher = new PasswordHasher<IdentityUser>();
            var SuperAdmin = new Applicaionuser
            {
                Id = userid, // Set a unique ID for the Admin user
                UserName = "SuperAdmin",
                NormalizedUserName = "superAdmin",
                Email = "SuperAdmin1995@gmail.com",
                NormalizedEmail = "SuperAdmin1995@gmail.com",
                EmailConfirmed = true
            };
            SuperAdmin.PasswordHash = hasher.HashPassword(SuperAdmin, "SuperAdmin1995@gmail.com"); // Set the password hash for the Admin user

            modelBuilder.Entity<Applicaionuser>().HasData(SuperAdmin);
            var adminRole = new IdentityRole
            {
                Id = RoleAdminId, // Set a unique ID for the Admin role
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            var superAdminRole = new IdentityRole
            {
                Id = RoleSuperAdminId, // Set a unique ID for the SuperAdmin role
                Name = "SuperAdmin",
                NormalizedName = "SUPERADMIN"
            };  
            
            var useraRole = new IdentityRole
            {
                Id = RoleUserID, // Set a unique ID for the SuperAdmin role
                Name = "User",
                NormalizedName = "user"
            };

            modelBuilder.Entity<IdentityRole>().HasData(
                adminRole,
                superAdminRole, useraRole
            );

            

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = userid,
                    RoleId = RoleSuperAdminId
                }
            // Add more user-role mappings as needed
            );
        }


    }

   
      


   
}








