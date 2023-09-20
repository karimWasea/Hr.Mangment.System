using DataAcess.layes;

using System.Text.Json.Serialization;

namespace HR_Api.Dtos
{
    public class EmployeedeviceDTO
    {
        public string Name { get; set; }

        public int Id { get; set; }


        public string Employeeid  { get; set; }
        
        
        public  List<int> devicids  { get; set; } 
        [JsonIgnore]
        public  int devicid  { get; set; }
         public  static EmployeeDevice    CanconvertViewmodel(EmployeedeviceDTO employeedeviceDTO)
        {
            return new EmployeeDevice
            {

                EmployeeId = employeedeviceDTO.Employeeid,
                DeviceId = employeedeviceDTO.devicid,
                Id = employeedeviceDTO.Id, 

            };
        }
    }
}
