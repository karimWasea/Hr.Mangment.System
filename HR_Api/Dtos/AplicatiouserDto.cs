using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using SystemEnums;

namespace HR_Api.Dtos;

public class AplicatiouserCreatDto
{

    [Required]
    public DateTime? BirthDate { get; set; } = DateTime.Now;
    [Required]
    public string? Address { get; set; }
    [Required]
    public decimal Salary { get; set; }
    [Required]
    public Gender Gender { get; set; }
    [Required]

    public int DepartmentId { get; set; }
    [Required]
    public string? JobTitle { get; set; }
    [Required]
    public string? PhoneNumber { get; set; }
    [Required]
    public DateTime? HirangDate { get; set; } = DateTime.Now;
    [Required]
    public IFormFile imgurlform { get; set; }
    [Required]
    public IFormFile contractUrlform { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]

    public string PasswordHash { get; set; }
    [Required]
    public string? contractUrl { get; set; }
    [Required]
    public string? ImgUrl { get; set; }

    public static Applicaionuser CanconvertViewmodel(AplicatiouserCreatDto aplicatiouserDto)
    {
        // Create a new instance of Applicaionuser
        Applicaionuser applicationUser = new Applicaionuser();

        // Map properties from AplicatiouserDto to Applicaionuser
        //applicationUser.Id = aplicatiouserDto.Id;
        applicationUser.BirthDate = aplicatiouserDto.BirthDate;
        applicationUser.HirangDate = aplicatiouserDto. HirangDate;
        applicationUser.Adress = aplicatiouserDto.Address;
        applicationUser.Salary = (double?)aplicatiouserDto.Salary;
        applicationUser.DepartmentId = aplicatiouserDto.DepartmentId;
        applicationUser.JobTitle = aplicatiouserDto.JobTitle;
        applicationUser.PhoneNumber = aplicatiouserDto.PhoneNumber;
        applicationUser.HirangDate = aplicatiouserDto.HirangDate;
        applicationUser.UserName = aplicatiouserDto.UserName;
        applicationUser.Email = aplicatiouserDto.Email;
        applicationUser.ContructUrl = aplicatiouserDto.contractUrl;
        applicationUser.PasswordHash = aplicatiouserDto.PasswordHash;
        applicationUser.ImgUrl = aplicatiouserDto.ImgUrl;

        // You might need to handle the IFormFile properties separately based on your requirements.
        // For example, save them to a specific location.

        return applicationUser;
    }




}

    public class AplicatiouserDtoUpdate: AplicatiouserCreatDto
{
        public string? Id { get; set; }

  

    public static Applicaionuser CanconvertViewmodel(AplicatiouserDtoUpdate aplicatiouserDto)
        {
            // Create a new instance of Applicaionuser
            Applicaionuser applicationUser = new Applicaionuser();

            // Map properties from AplicatiouserDto to Applicaionuser
            applicationUser.Id = aplicatiouserDto.Id;
            applicationUser.BirthDate = aplicatiouserDto.BirthDate;
            applicationUser.Adress = aplicatiouserDto.Address;
            applicationUser.HirangDate = aplicatiouserDto.HirangDate;
            applicationUser.Salary = (double?)aplicatiouserDto.Salary;
            applicationUser.DepartmentId = aplicatiouserDto.DepartmentId;
            //applicationUser.Bouns = (double?)aplicatiouserDto.Bouns;
            applicationUser.JobTitle = aplicatiouserDto.JobTitle;
            applicationUser.PhoneNumber = aplicatiouserDto.PhoneNumber;
            applicationUser.HirangDate = aplicatiouserDto.HirangDate;
            applicationUser.UserName = aplicatiouserDto.UserName;
            applicationUser.Email = aplicatiouserDto.Email;
            applicationUser.ContructUrl = aplicatiouserDto.contractUrl;
            applicationUser.PasswordHash = aplicatiouserDto.PasswordHash;
            applicationUser.ImgUrl = aplicatiouserDto.ImgUrl;

            // You might need to handle the IFormFile properties separately based on your requirements.
            // For example, save them to a specific location.

            return applicationUser;
        }











    }
