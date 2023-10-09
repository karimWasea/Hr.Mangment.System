namespace HR.ViewModel
{
    using DataAcess.layes;

    using Intersoft.Crosslight.Mobile;

    using Microsoft.AspNetCore.Http;
    using Microsoft.Identity.Client;

    using System;
    using System.ComponentModel.DataAnnotations;

    using SystemEnums;

    public class EmployeeVM
    {
        public static Applicaionuser CanconvertViewmodel(EmployeeVM ApplicationUser)
        {       

              
            return new Applicaionuser
            {
                Id = ApplicationUser.Id,
                UserName = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                Gender = ApplicationUser.Gender,
                Adress = ApplicationUser.Adress,
                BirthDate = ApplicationUser.BirthDate,
                PhoneNumber = ApplicationUser.PhoneNumber,
                ImgUrl = ApplicationUser.imgPath,
                //Bouns = ApplicationUser.Bouns,
                JobTitle = ApplicationUser.JobTitle,
                HirangDate = ApplicationUser.HirangDate,
                ContructUrl = ApplicationUser.ContructPath,
                Salary = ApplicationUser.Salary,
                DepartmentId = ApplicationUser.deptmentid,
                IsDeleted= ApplicationUser.iDeleted,
            };
        }

        public IsDeleted iDeleted { get; set; }

        public string Id { get; set; }
        public int deptmentid { get; set; }
        public double? Salary { get; set; }

        public double? Bouns { get; set; }
        public string? JobTitle { get; set; }
        public string? Adress { get; set; }
        public IFormFile ContructUrl { get; set; }      
        public IFormFile ImgUrl { get; set; }

        public string ContructPath { get; set; }
        public string? ManagerId { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HirangDate { get; set; }

        // User fields
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        //public IFormFile ImgUrls { get; set; }
        public string imgPath { get; set; }
        public Gender Gender { get; set; }
        public IsDeleted IsDeleted { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

    }
}