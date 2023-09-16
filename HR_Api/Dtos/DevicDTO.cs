using DataAcess.layes;

using HR_Api.Utellites;
namespace HR_Api.Dtos
{
    public class DevicDTO : BaseDTO
    {
   
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
