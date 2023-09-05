using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace HR.ViewModel
{
    public class TimeShiftVM : BaseViewModel
    {
        //public int Id { get; set; }

        public IsDeleted IsDeleted { get; set; } = IsDeleted.NotDeleted;
        public int? HoursPershift { get; set; }
        public ShiftStuTework shiftStuTework { get; set; }
        public DateTime? StartingTime { get; set; }
        public DateTime? EndingTime { get; set; }

        public string? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        

     
        
        public string FormattedDateTime { get; set; } // Display and input formatted date and time
        public DateTime? DateTime { get; set; } // Store the actual DateTime value        public IEnumerable<SelectListItem> Employes { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Shifts { get; set; } = Enumerable.Empty<SelectListItem>();
        public IEnumerable<SelectListItem> Employes { get; set; } = Enumerable.Empty<SelectListItem>();

        public static TimeShift CanconvertViewmodel(TimeShiftVM entity)
        {
            var dept = new TimeShift() {
             EmployeeId = entity.EmployeeId,
              EndingTime = entity.EndingTime,   
               shiftStuTework   = entity.shiftStuTework,
                 StartingTime = entity.StartingTime,
Id = entity.Id,                
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}