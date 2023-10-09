using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class TrainingDTO : BaseDTO
    {
        [Required]

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
