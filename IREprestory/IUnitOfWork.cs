using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IUnitOfWork
    { IDeparment Deparment {  get; }    
        Iemployee Employee { get;  }
    }
}
