using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class DevicDTO : BaseDTO
    {
        [Required]
        public   string Name { get; set; }

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
