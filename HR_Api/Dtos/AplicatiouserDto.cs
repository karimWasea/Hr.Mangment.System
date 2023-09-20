using DataAcess.layes;

using HR_Api.Utellites;

using SystemEnums;

namespace HR_Api.Dtos;

public class AplicatiouserDto
{
    public string? Id { get; set; }

    public DateTime? BirthDate { get; set; } = DateTime.Now;
    public string Address { get; set; }
    public decimal Salary { get; set; }
    //public int Gender { get; set; }

    public int DepartmentId { get; set; }
    public decimal Bouns { get; set; }
    public string JobTitle { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? HirangDate { get; set; } = DateTime.Now;
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? contracturl { get; set; }
    public string PasswordHash { get; set; }
    public IFormFile imgurlform { get; set; }
    public IFormFile contractUrlform { get; set; }
    public string? ImgUrl { get; set; }

    public static Applicaionuser CanconvertViewmodel(AplicatiouserDto aplicatiouserDto)
    {
        // Create a new instance of Applicaionuser
        Applicaionuser applicationUser = new Applicaionuser();

        // Map properties from AplicatiouserDto to Applicaionuser
        applicationUser.Id = aplicatiouserDto.Id;
        applicationUser.BirthDate = aplicatiouserDto.BirthDate;
        applicationUser.Adress = aplicatiouserDto.Address;
        applicationUser.Salary = (double?)aplicatiouserDto.Salary;
        applicationUser.DepartmentId = aplicatiouserDto.DepartmentId;
        applicationUser.Bouns = (double?)aplicatiouserDto.Bouns;
        applicationUser.JobTitle = aplicatiouserDto.JobTitle;
        applicationUser.PhoneNumber = aplicatiouserDto.PhoneNumber;
        applicationUser.HirangDate = aplicatiouserDto.HirangDate;
        applicationUser.UserName = aplicatiouserDto.UserName;
        applicationUser.Email = aplicatiouserDto.Email;
        //applicationUser.ContructUrl = aplicatiouserDto.contracturl;
        applicationUser.PasswordHash = aplicatiouserDto.PasswordHash;
        applicationUser.ImgUrl = aplicatiouserDto.ImgUrl;

        // You might need to handle the IFormFile properties separately based on your requirements.
        // For example, save them to a specific location.

        return applicationUser;
    }
}
