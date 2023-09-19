using HR_Api.Dtos;

namespace HR_Api.Irepreatory
{
    public interface Iemployee_Api : IPaginationHelper<EmployeeDTO>
    {

        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<EmployeeDTO> GetById(string id);
        //Task<EmployeeVM> GetByIdasconfirmed(string id);

        //Task<IEnumerable<EmployeeVM>> GetallconfirmedDoctor();
        Task<IEnumerable<EmployeeDTO>> Search(string str = default);

        Task Save(EmployeeDTO entity);






    }
}
