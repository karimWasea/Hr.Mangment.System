using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace HR.ViewModel
{
    public class EmployeeWorkScheduleCurentWeekDayVm : BaseViewModel
    {
        public IsDeleted IsDeleted { get; set; }


         
        


        [Required(ErrorMessage = "EmployeeId is required")]
        public string EmployeeId { get; set; }
        public int  Shiftid { get; set; }
        [Required(ErrorMessage = "EmployeeId is required")]

        public List<int> selectShiftids { get; set; }
        public string EmployeeName { get; set; }


 
        //public string DisplayShift
        //{
        //    get
        //    {
        //        return $"{DayName.ToString()} - {ShiftName}";
        //    }
        //}

        public IEnumerable<SelectListItem> DisplayShiftlist { get; set; } = Enumerable.Empty<SelectListItem>();

        public static EmployeeWorkScheduleCurentWeekDay CanconvertViewmodel(EmployeeWorkScheduleCurentWeekDayVm entity)
        {
            var dept = new EmployeeWorkScheduleCurentWeekDay{
  EmployeeId    = entity.EmployeeId,
        Id = (int)entity.Id,
IsDeleted= entity.isDeleted,

                TimeShiftId =
                entity.Shiftid,

            };


            return dept;
        }
    }
}