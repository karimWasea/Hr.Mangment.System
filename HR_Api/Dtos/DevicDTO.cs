using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{

    public class DevicDTOAdd 
    {
        [Required]
        public string Name { get; set; }
        public static Device ConvertTODTOToObj(DevicDTOAdd departmintDTO)
        {

            return new Device
            {

                DeviceName = departmintDTO.Name,


                 

            };
        }

    }


    public class DevicDTO  : DevicDTOAdd
    {
        public int Id { get; set; }

      

        public static Device ConvertTODTOToObj(DevicDTO departmintDTO)
        {

            return  new Device
            {

                DeviceName = departmintDTO.Name,

                Id = departmintDTO.Id
                 ,

            };   
        }
    
    }
}
