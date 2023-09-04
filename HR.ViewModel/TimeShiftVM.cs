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

        public string? EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public TimeSpan? StartingTime { get; set; }
        public TimeSpan? EndingTime { get; set; }
        public DateTime? dateTime { get; set; }
        public IEnumerable<SelectListItem> Mangers { get; set; } = Enumerable.Empty<SelectListItem>();

        public static TimeShift CanconvertViewmodel(TimeShiftVM entity)
        {
            var dept = new TimeShift() {
            dateTime  = entity.dateTime,
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