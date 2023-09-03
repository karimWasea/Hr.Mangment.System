using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace HR.ViewModel
{
    public class Depatmentvm :BaseViewModel
    {
        public int Id { get; set; }

        public string? DepartmentName { get; set; } 
        public string? MangerName { get; set; } 
        public string? ManagerId { get; set; }
        public IEnumerable<SelectListItem> Mangers { get; set; } = Enumerable.Empty<SelectListItem>();

        public static Department CanconvertViewmodel(Depatmentvm entity)
        {
            var dept = new Department() {
             DepartmentName = entity.DepartmentName,
             ManagerId = entity.ManagerId,
Id= entity.Id,                
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}