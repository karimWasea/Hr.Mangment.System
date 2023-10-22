using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace HR.ViewModel
{
    public class WorkScheduleCurentWeekDayVm : BaseViewModel
    {
        public IsDeleted IsDeleted { get; set; }


        [Required(ErrorMessage = "DayName is required")]
        public DayOfWeek DayName { get; set; }

        [Required(ErrorMessage = "ShiftName is required")]
        public string ShiftName { get; set; }

        //[Required(ErrorMessage = "EmployeeId is required")]
        //public string EmployeeId { get; set; }

        [Required(ErrorMessage = "TimestartShift is required")]
        public DateTime TimestartShift { get; set; }

        [Required(ErrorMessage = "TimeEndshifts is required")]
        public DateTime TimeEndshifts { get; set; }

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
       TimeEndshifts    = entity.TimestartShift, Id = (int)entity.Id,
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}