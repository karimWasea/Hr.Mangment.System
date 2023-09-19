using DataAcess.layes;

using HR_Api.Utellites;

namespace HR_Api.Dtos
{
  













        public class EmployeeDTO
        {
            public int Id { get; set; }
            public string ImgUrl { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Address { get; set; }
            public decimal Salary { get; set; }
            public Gender Gender { get; set; }

            public bool IsDeleted { get; set; }
            public int DepartmentId { get; set; }
            public decimal Bouns { get; set; }
            public string JobTitle { get; set; }
            public string ContructUrl { get; set; }
            public DateTime? HirangDate { get; set; }
            public string UserName { get; set; }
            public string NormalizedUserName { get; set; }
            public string Email { get; set; }
            public string NormalizedEmail { get; set; }
            public bool EmailConfirmed { get; set; }
            public string PasswordHash { get; set; }
   
     
     }
      


  
}
