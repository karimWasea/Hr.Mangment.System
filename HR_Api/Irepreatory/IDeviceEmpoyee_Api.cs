using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public interface IDeviceEmpoyee_Api : IRepository<EmployeedeviceDTO> 
    {
        IEnumerable<EmployeedeviceDTO> Employeedevicess(string str = default);
        IEnumerable<EmployeedeviceDTO> GetAll();
        EmployeeDevice Add(EmployeedeviceDTOAdd entity);
        EmployeeDevice Update(EmployeedeviceDTO entity);


    }
}
