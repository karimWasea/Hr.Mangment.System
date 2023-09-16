using DataAcess.layes;

using HR_Api.Utellites;
using System.ComponentModel.DataAnnotations;

namespace HR_Api.Dtos
{
    public class WorkScheduleCurentWeekDayDTO : BaseDTO
    {
        public DayOfWeek DayName { get; set; }

        public string ShiftName { get; set; }
        public DateTime TimestartShift { get; set; }
        public DateTime TimeEndshifts { get; set; }
        public static WorkScheduleCurentWeekDay ConvertTODTOToObj(WorkScheduleCurentWeekDayDTO departmintDTO)
        {

            return  new WorkScheduleCurentWeekDay
            {

                ShiftName = departmintDTO.Name,
            
               Id = departmintDTO.Id
                 ,

            };   
        }
    
    }
}
