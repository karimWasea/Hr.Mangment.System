using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork _unitOfWork;
        protected lookupServess _lookupServess;
        public BaseController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }
      

    }
}
