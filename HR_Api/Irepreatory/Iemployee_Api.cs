using apistudy.Models.Entityies;

using HR_Api.Dtos;

namespace HR_Api.Irepreatory
{
    public interface Iemployee_Api : IPaginationHelper<AplicatiouserDtoUpdate>
    {

        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<AplicatiouserDtoUpdate> GetById(string id);
        //Task<EmployeeVM> GetByIdasconfirmed(string id);

        //Task<IEnumerable<EmployeeVM>> GetallconfirmedDoctor();
        Task<IEnumerable<AplicatiouserDtoUpdate>> Search(string str = default);

        Task<AuthModel> Creat(AplicatiouserCreatDto entity);
        Task<AuthModel> Update(AplicatiouserDtoUpdate entity);






    }
}
