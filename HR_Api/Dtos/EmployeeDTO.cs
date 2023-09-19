using DataAcess.layes;

using HR_Api.Utellites;

using System.Text.Json.Serialization;

namespace HR_Api.Dtos
{
  













        public class EmployeeDTO
        {
            public string Id { get; set; }
        [JsonIgnore]
            public string ImgUrl { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Address { get; set; }
            public decimal Salary { get; set; }
            public Gender Gender { get; set; }

            public int DepartmentId { get; set; }
            public decimal Bouns { get; set; }
            public string JobTitle { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime? HirangDate { get; set; }
            public string UserName { get; set; }
            public string NormalizedUserName { get; set; }
            public string Email { get; set; }
            public string imgurl { get; set; }
            public string contracturl { get; set; }
            public string NormalizedEmail { get; set; }
            public string PasswordHash { get; set; }
            public IFormFile  imgurlform { get; set; }
            public IFormFile contractUrlform { get; set; }
   
     
     }
      


  
}
