using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace HR.ViewModel
{
    public class WorkScheduleCurentWeekDayVm : BaseViewModel
    {
        public IsDeleted IsDeleted { get; set; } 

        public DayOfWeek DayName { get; set; }
        public string ShiftName { get; set; }
        public string EmployeeId { get; set; }
        public DateTime? TimestartShift { get; set; }
        public DateTime? TimeEndshifts { get; set; }
        [NotMapped]
        public string DisplayShift
        {
            get
            {
                return $"{DayName.ToString()} - {ShiftName}";
            }
        }

        public IEnumerable<SelectListItem> DayNameslist { get; set; } = Enumerable.Empty<SelectListItem>();

        public static WorkScheduleCurentWeekDay CanconvertViewmodel(WorkScheduleCurentWeekDayVm entity)
        {
            var dept = new WorkScheduleCurentWeekDay{
 DayName    = entity.DayName,
   //EmployeeId = entity.EmployeeId,
    TimestartShift = entity.TimestartShift,
      ShiftName = entity.ShiftName,
       TimeEndshifts    = entity.TimestartShift, Id = entity.Id,
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}