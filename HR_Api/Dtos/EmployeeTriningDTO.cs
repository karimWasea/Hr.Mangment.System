using DataAcess.layes;

using HR_Api.Utellites;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HR_Api.Dtos
{
    public class EmployeeTriningDTOAdd
    {


        [Required]
        public string? EmployeeId { get; set; }

        [JsonIgnore]
        public int TrainingId { get; set; }
        [Required] public List<int> TrainiIngIds { get; set; }

    }




    public class EmployeeTriningDTO: EmployeeTriningDTOAdd
    { 
      [Required]
    public int Id { get; set; }

        //public static EmployeeTraining ConvertTODTOToObj(EmployeeTriningDTO departmintDTO)
        //{

        //    return  new  EmployeeTraining
        //    { 
            
        //      EmployeeId = departmintDTO.EmployeeId,
        //      TrainingId = departmintDTO.TrainingId,
             
        //       Id = departmintDTO.Id
        //         ,

        //    };   
        //}
    
    }
}
