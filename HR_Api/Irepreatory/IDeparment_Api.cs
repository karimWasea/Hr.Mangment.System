using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public interface IDeparment_Api : IRepository<DepartmintDTO>
    {
        Department Add(DepartmintDTOAdd entity);
        Department Update(DepartmintDTO entity);
    }
}
