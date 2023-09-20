using HR_Api.IrepreatoryServess;

namespace HR_Api.Irepreatory
{
    public interface IunitofWork : IDisposable
    { IDeparment_Api Deparment { get; }
         IDevice_Api Device { get; }  
         IWorkScheduleCurentWeekDay_Api WorkScheduleCurentWeekDay { get; }
         IVaction_Api Vaction { get; }
         ITrining_Api trining { get; }
         Iemployee_Api  Employee { get; }
        IDeviceEmpoyee_Api deviceEmpoyee { get; }
         ISalarytransaction_Api salarytransaction_Api { get; }


    }
}
