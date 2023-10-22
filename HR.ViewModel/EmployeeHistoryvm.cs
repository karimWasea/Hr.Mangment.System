using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace HR.ViewModel
{
    public class EmployeeHistoryvm : BaseViewModel
    {
        public decimal? TotalSalary { get; set; }
        public DateTime Month { get; set; } = DateTime.Now.Date.AddDays(1 - DateTime.Now.Day);
        public string EmployeeId { get; set; }

        public IEnumerable<SelectListItem> Mangers { get; set; } = Enumerable.Empty<SelectListItem>();

        public static EmployeeHistory CanconvertViewmodel(EmployeeHistoryvm entity)
        {
            var dept = new EmployeeHistory() {
              
Id= (int)entity.Id,                
IsDeleted= entity.isDeleted,                
            
       EmployeeId= entity.EmployeeId,
        Month= entity.Month,
             TotalSalary = entity.TotalSalary   
            
            };


            return dept;
        }
    }
}