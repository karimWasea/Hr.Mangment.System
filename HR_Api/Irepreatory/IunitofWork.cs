using HR_Api.IrepreatoryServess;

namespace HR_Api.Irepreatory
{
    public interface IunitofWork : IDisposable
    { IDeparment_Api Deparment { get; }
         IDevice_Api Device { get; }  
         IWorkScheduleCurentWeekDay_Api WorkScheduleCurentWeekDay { get; }
         IVaction_Api Vaction { get; }
         ITrining_Api trining { get; }
          
    }
}
