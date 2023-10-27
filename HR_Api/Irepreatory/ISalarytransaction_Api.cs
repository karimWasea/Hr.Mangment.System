using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public interface ISalarytransaction_Api : IRepository<SalaryTransactionTO>
    {
        SalaryTransaction Add(SalaryTransactionTOAdd entity);
        SalaryTransaction Update(SalaryTransactionTO entity);
        IEnumerable<SalaryTransactionTO> GetByEmployeeIdALLtrantionforemployee(string id);

    }
}
