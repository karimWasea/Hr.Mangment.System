using HR_Api.IrepreatoryServess;

namespace HR_Api.Irepreatory
{
    public interface IunitofWork : IDisposable
    { IDeparment_Api Deparment { get; }
    }
}
