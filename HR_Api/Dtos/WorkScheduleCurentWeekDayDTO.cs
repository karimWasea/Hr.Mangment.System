﻿using DataAcess.layes;

using HR_Api.Utellites;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using SystemEnums;

namespace HR_Api.Dtos
{
    public class WorkScheduleCurentWeekDayDTO : BaseDTO
    {
        [JsonIgnore]
        public DayOfWeek DayNames { get; set; }

        public string Name { get; set; }





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
