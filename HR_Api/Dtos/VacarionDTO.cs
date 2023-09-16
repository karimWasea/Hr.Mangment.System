using DataAcess.layes;

using HR_Api.Utellites;
namespace HR_Api.Dtos
{
    public class VacarionDTO :BaseDTO
    {

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

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
