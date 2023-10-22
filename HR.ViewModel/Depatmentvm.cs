using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR.ViewModel
{
    public class Depatmentvm :BaseViewModel
    {
        [Required(ErrorMessage = "The DepartmentName field is required.")]

        public string DepartmentName { get; set; } 
        public string? MangerName { get; set; } =string.Empty;
        [Required(ErrorMessage = "The manger field is required.")]

        public string ManagerId { get; set; } = default!;

        public IEnumerable<SelectListItem> Mangers { get; set; } = Enumerable.Empty<SelectListItem>();

        public static Department CanconvertViewmodel(Depatmentvm entity)
        {
            var dept = new Department {
             DepartmentName = entity.DepartmentName,
             ManagerId = entity.ManagerId,
Id= (int)entity.Id,                
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}