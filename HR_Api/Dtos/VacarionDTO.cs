using DataAcess.layes;

using HR_Api.Utellites;
using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class VacarionDTO :BaseDTO
    {
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }
        [Required]
        public string EmployeeId { get; set; }
        public static Vacation ConvertTODTOToObj(VacarionDTO departmintDTO)
        {

            return  new Vacation
            { 
            
             StartDate = departmintDTO.StartDate,
               Id = departmintDTO.Id
                 ,
                
                
                EndDate = departmintDTO.EndDate,
               EmployeeId = departmintDTO.EmployeeId
                 ,

            };   
        }
    
    }
}
