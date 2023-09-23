using apistudy.Models.Entityies;

using HR_Api.Dtos;

namespace HR_Api.Irepreatory
{
    public interface Iemployee_Api : IPaginationHelper<AplicatiouserDto>
    {

        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<AplicatiouserDto> GetById(string id);
        //Task<EmployeeVM> GetByIdasconfirmed(string id);

        //Task<IEnumerable<EmployeeVM>> GetallconfirmedDoctor();
        Task<IEnumerable<AplicatiouserDto>> Search(string str = default);

        Task<AuthModel> Creat(AplicatiouserDtoCreat entity);
        Task<AuthModel> Update(AplicatiouserDto entity);






    }
}
