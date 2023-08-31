//namespace HR.ViewModel
//{
//    using DataAcess.layes;

//    using Intersoft.Crosslight.Mobile;

//    using Microsoft.AspNetCore.Http;

//    using System;
//    using System.ComponentModel.DataAnnotations;

//    using SystemEnums;

//    public class EmployeeVM
//    {
//        public static Employee CanconvertViewmodel(EmployeeVM ApplicationUser)
//        {
//            return new Employee
//            {
//                Id = ApplicationUser.Id,
//                UserName = ApplicationUser.UserName,

//                Email = ApplicationUser.Email,
//                Gender = ApplicationUser.Gender,
//                Adress = ApplicationUser.Adress,
//                BirthDate = ApplicationUser.BirthDate,
//                PhoneNumber = ApplicationUser.Phonenumber,
//                Nationality = ApplicationUser.Nationality,
//                imphgurl = ApplicationUser.imphgurl,
//                PostalCode = ApplicationUser.PostalCode,
//                Title = ApplicationUser.Title,
//                HiringDate = ApplicationUser.HiringDate,
//                Contracturl = ApplicationUser.Contracturl,
//                statusDoctorInSystem = ApplicationUser.StatusDoctorInSystem,
//                WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
//                Salary = ApplicationUser.Salary,
//            };
//        }


//        public string Id { get; set; }
//        public double? Salary { get; set; }

//        public double? Bouns { get; set; }
//        public string? JobTitle { get; set; }
//        public string? Adress { get; set; }
//        public string? ContructUrl { get; set; }
//        public DateTime? BirthDate { get; set; }
//        public DateTime? HirangDate { get; set; }

//        // User fields
//        public string? UserName { get; set; }
//        public string? NormalizedUserName { get; set; }
//        public string? Email { get; set; }
//        public string? NormalizedEmail { get; set; }
//        public bool EmailConfirmed { get; set; }
//        public string? PasswordHash { get; set; }
//        public string? SecurityStamp { get; set; }
//        public string? ConcurrencyStamp { get; set; }
//        public string? PhoneNumber { get; set; }
//        public IFormFile ImgUrl { get; set; }
//        public Gender  Gender { get; set; }
//        public IsDeleted IsDeleted { get; set; }
//        public bool PhoneNumberConfirmed { get; set; }
//        public bool TwoFactorEnabled { get; set; }
//        public DateTimeOffset? LockoutEnd { get; set; }
//        public bool LockoutEnabled { get; set; }
//        public int AccessFailedCount { get; set; }

//    }
//}