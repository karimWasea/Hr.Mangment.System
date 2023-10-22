using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SystemEnums;

namespace HR.ViewModel
{
    public class EmployeeDeviceVm : BaseViewModel
    {


           



        [Required(ErrorMessage = "EmployeeId is required")]
        public string EmployeeId { get; set; }
        public int  Deviceid { get; set; }
        [Required(ErrorMessage = "selectShiftids is required")]

        public List<int> selectDeviceids { get; set; }
        public string? EmployeeName { get; set; }


 
        //public string DisplayShift
        //{
        //    get
        //    {
        //        return $"{DayName.ToString()} - {ShiftName}";
        //    }
        //}

        public IEnumerable<SelectListItem> DisplayDeviceid { get; set; } = Enumerable.Empty<SelectListItem>();

        public static EmployeeDevice CanconvertViewmodel(EmployeeDeviceVm entity)
        {
            var dept = new EmployeeDevice
            {
  EmployeeId    = entity.EmployeeId,
        Id = (int)entity.Id,
IsDeleted= entity.isDeleted,

                DeviceId =
                entity.Deviceid,

            };


            return dept;
        }
    }
}