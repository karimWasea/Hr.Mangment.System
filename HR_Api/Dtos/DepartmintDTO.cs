using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class DepartmintDTOAdd
    {
        public string Name { get; set; }
        [Required]

        public string? ManagerId { get; set; }
        public string? mangerName { get; set; }
        public static Department ConvertTODTOToObj(DepartmintDTOAdd departmintDTO)
        {

            return new Department
            {

                DepartmentName = departmintDTO.Name,
                ManagerId = departmintDTO.ManagerId,

                 


            };
        }

    }
    public class DepartmintDTO  :DepartmintDTOAdd
    {
        [Required]
        public int Id { get; set; }
      
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
