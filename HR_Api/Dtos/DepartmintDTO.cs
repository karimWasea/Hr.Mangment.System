using DataAcess.layes;

using HR_Api.Utellites;
namespace HR_Api.Dtos
{
    public class DepartmintDTO :BaseDTO
    {
        public string Name { get; set; }

        public string?  ManagerId { get; set; }
        public string? mangerName { get; set; }
            public static  Department ConvertTODTOToObj(DepartmintDTO departmintDTO)
        {

            return  new Department { 
            
             DepartmentName = departmintDTO.Name,
              ManagerId = departmintDTO.ManagerId,
               Id = departmintDTO.Id
                 ,

            };   
        }
    
    }
}
