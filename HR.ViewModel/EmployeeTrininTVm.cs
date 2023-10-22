using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace HR.ViewModel
{
    public class EmployeeTrininTVm : BaseViewModel
    {
        public IsDeleted IsDeleted { get; set; }


         



        [Required(ErrorMessage = "EmployeeId is required")]
        public string EmployeeId { get; set; }
        public int  Triningid { get; set; }
        [Required(ErrorMessage = "selectShiftids is required")]

        public List<int> selectTriningids { get; set; }
        public string EmployeeName { get; set; }


 
        //public string DisplayShift
        //{
        //    get
        //    {
        //        return $"{DayName.ToString()} - {ShiftName}";
        //    }
        //}

        public IEnumerable<SelectListItem> DisplayTrining { get; set; } = Enumerable.Empty<SelectListItem>();

        public static EmployeeTraining CanconvertViewmodel(EmployeeTrininTVm entity)
        {
            var dept = new EmployeeTraining
            {
  EmployeeId    = entity.EmployeeId,
        Id = (int)entity.Id,
IsDeleted= entity.isDeleted,

                TrainingId =
                entity.Triningid,

            };


            return dept;
        }
    }
}