using HR_Api.Dtos;
using HR_Api.Irepreatory;

namespace HR_Api.IrepreatoryServess
{
    public interface IDeviceEmpoyee_Api : IRepository<EmployeedeviceDTO> 
    {
        IEnumerable<EmployeedeviceDTO> Employeedevicess(string str = default);
        IEnumerable<EmployeedeviceDTO> GetAll();


    }
}
