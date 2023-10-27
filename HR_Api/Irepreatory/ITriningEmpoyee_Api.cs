using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;



namespace HR_Api.IrepreatoryServess
{
    public interface ITriningEmpoyee_Api : IRepository<EmployeeTriningDTO>
    {
        EmployeeTraining Add(EmployeeTriningDTOAdd entity);
        EmployeeTraining Update(EmployeeTriningDTO entity);
        IEnumerable<EmployeeTriningDTO> EmployeeTRining(string str = default);
        IEnumerable<EmployeeTriningDTO> GetAll();


    }
}
