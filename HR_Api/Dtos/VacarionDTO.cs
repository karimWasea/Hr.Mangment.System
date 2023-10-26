using DataAcess.layes;

using HR_Api.Utellites;
using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class VacarionDTOADD
    {
        [Required(ErrorMessage = "isrequired")]
        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "isrequired")]
        public DateTime? EndDate { get; set; }
        [Required(ErrorMessage = "isrequired")]
        public string EmployeeId { get; set; }


    }
    public class VacarionDTO : VacarionDTOADD
    {
        public int Id { get; set; }

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
