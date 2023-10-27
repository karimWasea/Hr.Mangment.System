using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using SystemEnums;

namespace HR_Api.Dtos
{
    public class WorkScheduleCurentWeekDayDTOADD
    {



        public DayOfWeek DayNames { get; set; }
        [Required]

        public string Name { get; set; }




        [Required]


        public string ShiftName { get; set; }
        [Required]

        public DateTime TimestartShift { get; set; }
        [Required]

        public DateTime TimeEndshifts { get; set; }
        public static WorkScheduleCurentWeekDay ConvertTODTOToObj(WorkScheduleCurentWeekDayDTOADD departmintDTO)
        {

            return new WorkScheduleCurentWeekDay
            {
                 TimeEndshifts = departmintDTO.TimeEndshifts,
                  DayName   = departmintDTO.DayNames,
                   TimestartShift = departmintDTO.TimestartShift,

                ShiftName = departmintDTO.Name,

                 

            };
        }
    }

    public class WorkScheduleCurentWeekDayDTO :  WorkScheduleCurentWeekDayDTOADD
    {
       


        [Required]
        public int Id { get; set; }
        public static WorkScheduleCurentWeekDay ConvertTODTOToObjUpdate(WorkScheduleCurentWeekDayDTO departmintDTO)
        {

            return new WorkScheduleCurentWeekDay
            {

                ShiftName = departmintDTO.Name,
                TimeEndshifts = departmintDTO.TimeEndshifts,
                DayName = departmintDTO.DayNames,
                TimestartShift = departmintDTO.TimestartShift,


                Id = departmintDTO.Id
                 ,

            };
        }


    }
}
