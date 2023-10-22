using DataAcess.layes;

using HR.Utailites;
using HR.ViewModel;

using Intersoft.Crosslight;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
    [Authorize(Roles = SystemRols.SuperAdmin)]


    public class SalaryTransactionController : BaseController
    {
       
        UserManager<Applicaionuser> _userManager;
        public SalaryTransactionController(UnitOfWork unitOfWork, lookupServess lookupServess, UserManager<Applicaionuser> userManager
) :base(unitOfWork, lookupServess)
        {
            _userManager=userManager;
        

        
        }
        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.SalaryTransaction.GetAll();
            int pageNumber = page ?? 1;

            

            var pagedPatients = _unitOfWork.Deparment.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

        public IActionResult GEtAllemplyStranstion(int? page, string search, string Employeeid)
        {
            var model = _unitOfWork.SalaryTransaction.GetByEmployeeIdALLtrantionforemployee(Employeeid);
            int pageNumber = page ?? 1;

        

            var pagedPatients = _unitOfWork.Deparment.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }




        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id)
        {


            if (id > 0)
            {
                var model = _unitOfWork.SalaryTransaction.GetById(id);
                model.EmployeeAll = _lookupServess.EmployeeAll();
                model.ALLtransactionTyps = _lookupServess.GetAlltransaction();
                return View(model);
            }
            else
            {
                var vewodel = new SalaryTransactionVM();
                vewodel.EmployeeAll = _lookupServess.EmployeeAll();
                vewodel.ALLtransactionTyps = _lookupServess.GetAlltransaction();

                return View(vewodel);
            }

        }
        //Edite
        public async Task<IActionResult> EditGetbyemployeeonetrataction(string EmployeeId, string EmplyeeName)
        {


            var model = _unitOfWork.SalaryTransaction.GEtByemployeeId(EmployeeId);
            model.EmployeeName = EmplyeeName;
            model.EmployeeId = EmployeeId;
            model.EmployeeAll = _lookupServess.EmployeeAll();
            model.ALLtransactionTyps = _lookupServess.GetAlltransaction();
            return View(model);
        }


    
        public IActionResult Addtrantionforemplyee(string EmployeeId, string EmplyeeName) { 
           
                var vewodel = new SalaryTransactionVM();
                // Assuming vewodel is an instance of your view model
                vewodel.EmployeeName = EmplyeeName;
                vewodel.EmployeeId= EmployeeId;
                vewodel.EmployeeAll = _lookupServess.EmployeeAll();
                vewodel.ALLtransactionTyps = _lookupServess.GetAlltransaction();

            return View(vewodel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SalaryTransactionVM emp1)
        {
            emp1.ALLtransactionTyps = _lookupServess.GetAlltransaction();
            emp1.EmployeeAll = _lookupServess.EmployeeAll();

            if (ModelState.IsValid)
            {
                _unitOfWork.SalaryTransaction.Save(emp1);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction(nameof(Index));
            }
            return View(emp1);


        }

        public async Task<IActionResult> Remove(int  id)
        {
          _unitOfWork.SalaryTransaction.Delete(id);
            
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction(nameof(Index));
        }
    }
}
