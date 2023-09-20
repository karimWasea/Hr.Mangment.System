using HR_Api.Dtos;
using HR_Api.Irepreatory;

namespace HR_Api.IrepreatoryServess
{
    public interface ISalarytransaction_Api : IRepository<SalaryTransactionTO>
    {
        IEnumerable<SalaryTransactionTO> GetByEmployeeIdALLtrantionforemployee(string id);

    }
}
