using DataAcess.layes;

using HR_Api.Utellites;
namespace HR_Api.Dtos
{
    public class TrainingDTO : BaseDTO
    {
        public string Name { get; set; }

        public string? TrainingName { get; set; }
        public static Training ConvertTODTOToObj(TrainingDTO departmintDTO)
        {

            return  new Training
            {

                TrainingName = departmintDTO.TrainingName,
               Id = departmintDTO.Id
                 ,

            };   
        }
    
    }
}
