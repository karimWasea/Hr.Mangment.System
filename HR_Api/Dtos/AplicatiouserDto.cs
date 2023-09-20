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
   public int  Gender { get; set; }

    public int DepartmentId { get; set; }
    public decimal Bouns { get; set; }
    public string JobTitle { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? HirangDate { get; set; }= DateTime.Now;
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? contracturl { get;   set; }
    public string PasswordHash { get; set; }
    public IFormFile imgurlform { get; set; }
    public IFormFile contractUrlform { get; set; }
    public string? ImgUrl { get;   set; }
}
