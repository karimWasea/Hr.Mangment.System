using apistudy.Models.Entityies;

using HR_Api.Dtos;

namespace HR_Api.Irepreatory
{
    public interface ISystemRole_Api : IPaginationHelper<SystemRolsDtoUpdate>
    {

        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<SystemRolsDtoUpdate> GetById(string id);
        //Task<EmployeeVM> GetByIdasconfirmed(string id);

        //Task<IEnumerable<EmployeeVM>> GetallconfirmedDoctor();
        Task<IEnumerable<SystemRolsDtoUpdate>> Search(string str = default);

        Task<AuthModel> Creat(SystemRolsDtoCreate entity);
        Task<AuthModel> Update(SystemRolsDtoUpdate entity);






    }
}
