using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR.ViewModel
{
    public class Devicetvm : BaseViewModel                                          
    {
        [Required]
        public string DeviceName { get; set; }

        public IEnumerable<SelectListItem> Mangers { get; set; } = Enumerable.Empty<SelectListItem>();

        public static Device CanconvertViewmodel(Devicetvm entity)
        {
            var dept = new Device {
            DeviceName = entity.DeviceName,
             
Id= entity.Id,                
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}