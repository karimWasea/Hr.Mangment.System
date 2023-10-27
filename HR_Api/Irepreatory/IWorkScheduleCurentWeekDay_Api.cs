using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

 
namespace HR_Api.IrepreatoryServess
{
    public interface IWorkScheduleCurentWeekDay_Api : IRepository<WorkScheduleCurentWeekDayDTO>
    {
        WorkScheduleCurentWeekDay Add(WorkScheduleCurentWeekDayDTOADD entity);
        WorkScheduleCurentWeekDay Update(WorkScheduleCurentWeekDayDTO entity);
    }
}
