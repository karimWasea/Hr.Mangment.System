using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

using SystemEnums;

namespace HR.ViewModel
{
    public class VactionVm : BaseViewModel
    {
        //public int Id { get; set; }
        [Required(ErrorMessage = "  is required")]

        public DateTime? StartDate { get; set; }
        [Required(ErrorMessage = "  is required")]

        public DateTime? EndDate { get; set; }


        [Required(ErrorMessage = "  is required")]


        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }
        

     
     
        public IEnumerable<SelectListItem> Shifts { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Employes { get; set; } = Enumerable.Empty<SelectListItem>();

        public static Vacation CanconvertViewmodel(VactionVm entity)
        {
            var dept = new Vacation() {
             EmployeeId = entity.EmployeeId,
              EndDate = entity.EndDate,
               StartDate = entity.StartDate,
Id = (int)entity.Id,                
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}