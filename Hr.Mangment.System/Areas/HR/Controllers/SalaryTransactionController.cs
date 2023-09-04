using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]

    public class SalaryTransactionController : Controller
    {
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public SalaryTransactionController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.SalaryTransaction.GetAll();
            int pageNumber = page ?? 1;

            //if (!string.IsNullOrWhiteSpace(search))
            //{
            //    // Apply search filtering here based on your model properties
            //    model = model.Where(patient =>
            //      _unitOfWork.Employee.SearchProperty(patient.Reason, search) ||
            //         _unitOfWork.Employee.SearchProperty(patient.MangerName, search) 

            //    // Add more properties for search as needed
            //    );
            //}

            var pagedPatients = _unitOfWork.Deparment.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

        public IActionResult GEtAllemplyStranstion(int? page, string search, string Employeeid)
        {
            var model = _unitOfWork.SalaryTransaction.GetByEmployeeId(Employeeid);
            int pageNumber = page ?? 1;

            //if (!string.IsNullOrWhiteSpace(search))
            //{
            //    // Apply search filtering here based on your model properties
            //    model = model.Where(patient =>
            //      _unitOfWork.Employee.SearchProperty(patient.Reason, search) ||
            //         _unitOfWork.Employee.SearchProperty(patient.MangerName, search) 

            //    // Add more properties for search as needed
            //    );
            //}

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

        // POST: EmployeeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(SalaryTransactionVM emp1)
        {
            //if (ModelState.IsValid)
            //{
            _unitOfWork.SalaryTransaction.Save(emp1);
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction(nameof(Index));
            //}
            //  return View(emp1); 


        }

        // GET: EmployeeController/Delete/5


    
        // POST: EmployeeController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int  id)
        {
          _unitOfWork.SalaryTransaction.Delete(id);
            
            TempData["Message"] = $" successfully!";
            TempData["MessageType"] = "Save";
            return RedirectToAction(nameof(Index));
        }
    }
}
