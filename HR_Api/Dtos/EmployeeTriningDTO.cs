using DataAcess.layes;

using HR_Api.Utellites;
using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class EmployeeTriningDTO : BaseDTO
    {
        [Required]
        public string? EmployeeId { get; set; }
        [Required]

        public int TrainingId { get; set; }
        [Required]
        public  List <int> TrainiIngIds { get; set; }
        public static EmployeeTraining ConvertTODTOToObj(EmployeeTriningDTO departmintDTO)
        {

            return  new  EmployeeTraining
            { 
            
              EmployeeId = departmintDTO.EmployeeId,
              TrainingId = departmintDTO.TrainingId,
             
               Id = departmintDTO.Id
                 ,

            };   
        }
    
    }
}
