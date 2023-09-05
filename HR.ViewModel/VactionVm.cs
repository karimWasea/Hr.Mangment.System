using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace HR.ViewModel
{
    public class VactionVm : BaseViewModel
    {
        //public int Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

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
Id = entity.Id,                
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}