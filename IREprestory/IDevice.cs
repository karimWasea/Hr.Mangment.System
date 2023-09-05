using HR.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IDevice : IRepository<Devicetvm> , IPaginationHelper<Devicetvm>
    {
        //VactionVm GETVATIONEMPOYEEID(string id);
    }
}
