using HR.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IVaction : IRepository<VactionVm> , IPaginationHelper<VactionVm>
    {
        VactionVm GETVATIONEMPOYEEID(string id);
    }
}
