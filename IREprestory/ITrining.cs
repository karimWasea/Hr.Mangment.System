﻿using HR.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface ITrining  : IRepository<Trainingvm> , IPaginationHelper<Trainingvm>
    {
        //VactionVm GETVATIONEMPOYEEID(string id);
    }
}
