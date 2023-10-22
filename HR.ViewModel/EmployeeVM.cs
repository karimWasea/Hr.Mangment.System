namespace HR.ViewModel
{
    using DataAcess.layes;
    using HR.Utailites;

    using Intersoft.Crosslight.Mobile;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> listGender { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> alldept { get; set; } = Enumerable.Empty<SelectListItem>();

        public string Id { get; set; }
        [Required(ErrorMessage = "is requred")]

        public int deptmentid { get; set; }
        [Required(ErrorMessage = "is requred")]

        public double? Salary { get; set; }

        public double? Bouns { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string? JobTitle { get; set; }

        [Required(ErrorMessage = "is requred")]

        public string? Adress { get; set; }
        [ValidateImage(ErrorMessage = "Please upload a valid image (JPEG or PNG) and ensure it is less than 5MB.")]

        public IFormFile ContructUrl { get; set; }
        [ValidateImage(ErrorMessage = "Please upload a valid image (JPEG or PNG) and ensure it is less than 5MB.")]

        public IFormFile ImgUrl { get; set; }


        public string ContructPath { get; set; }=
        string.Empty;

        public string? ManagerId { get; set; } =string.Empty;
        //[Required]
        [Required(ErrorMessage = "is requred")]

        public DateTime? BirthDate { get; set; }
        //[Required]
        [Required(ErrorMessage = "is requred")]

        public DateTime? HirangDate { get; set; }

        // User fields
        //[Required]
        [Required(ErrorMessage = "is requred")]

        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        //[Required]
        [Required(ErrorMessage = "is requred")]

        public string? Email { get; set; }

        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        [Required(ErrorMessage = "is requred")]

        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        //[Required]
        [Required(ErrorMessage = "is requred")]

        public string? PhoneNumber { get; set; }
        //public IFormFile ImgUrls { get; set; }
        //[Required]

        public string imgPath { get; set; } = string.Empty; 
        //[Required]
        [Required(ErrorMessage = "is requred")]

        public Gender Gender { get; set; }
        public IsDeleted IsDeleted { get; set; }

        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

    }
}