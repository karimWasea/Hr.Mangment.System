using HR_Api.Dtos;
using HR_Api.Irepreatory;

namespace HR_Api.IrepreatoryServess
{
    public interface ITriningEmpoyee_Api : IRepository<EmployeeTriningDTO> 
    {
        IEnumerable<EmployeeTriningDTO> EmployeeTRining(string str = default);
        IEnumerable<EmployeeTriningDTO> GetAll();


    }
}
