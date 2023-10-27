using DataAcess.layes;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HR_Api.Dtos
{
    public class EmployeedeviceDTOAdd
    {
      


        [Required]
        public string Employeeid { get; set; }

        [Required]
        public List<int> devicids { get; set; }
        [JsonIgnore]
        public int devicid { get; set; }
        //public static EmployeeDevice CanconvertViewmodel(EmployeedeviceDTOAdd employeedeviceDTO)
        //{
        //    return new EmployeeDevice
        //    {

        //        EmployeeId = employeedeviceDTO.Employeeid,
        //        DeviceId = employeedeviceDTO.devicid,


        //    };
        //}

    }
    public class EmployeedeviceDTO : EmployeedeviceDTOAdd
    {
      
        [Required]
        public int Id { get; set; }

        // public  static EmployeeDevice    CanconvertViewmodel(EmployeedeviceDTO employeedeviceDTO)
        //{
        //    return new EmployeeDevice
        //    {

        //        EmployeeId = employeedeviceDTO.Employeeid,
        //        DeviceId = employeedeviceDTO.devicid,
        //        Id = employeedeviceDTO.Id, 

        //    };
        //}
    }
}
