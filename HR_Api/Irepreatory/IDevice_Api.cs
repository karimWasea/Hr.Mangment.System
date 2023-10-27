using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public interface IDevice_Api : IRepository<DevicDTO>
    {
        Device Add(DevicDTOAdd entity);
        Device Update(DevicDTO entity);
    }
}
