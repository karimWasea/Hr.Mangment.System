using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class TrainingDTOAdd
    {
        [Required]

        public string? TrainingName { get; set; }
        public static Training ConvertTODTOToObj(TrainingDTOAdd departmintDTO)
        {

            return new Training
            {

                TrainingName = departmintDTO.TrainingName,
              
            };
        }


    }


    public class TrainingDTOUppdate : TrainingDTOAdd
    {
        [Required]
        public int Id { get; set; }
      
        public static Training ConvertTODTOToObj(TrainingDTOUppdate departmintDTO)
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
