using DataAcess.layes;

using HR_Api.Utellites;
namespace HR_Api.Dtos
{
    public class EmployeeTriningDTO : BaseDTO
    {
        public string? EmployeeId { get; set; }

        public int TrainingId { get; set; }
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
