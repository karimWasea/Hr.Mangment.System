using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ReprestoryServess;

using System.Collections.Generic;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]

    public class EmployeeTriningController : Controller
    {
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public EmployeeTriningController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.employeetrining.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Deparment.SearchProperty(patient.EmployeeName, search)

                //Add more properties for search as needed
                );
            }
















            var pagedPatients = _unitOfWork.workScheduleCurentWeekDay.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

  
        public IActionResult GetAssinedTring(int? page, string search, string employeeid)
        {
            var model = _unitOfWork.employeetrining.GetAllShiftByemployeeId(employeeid);
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Deparment.SearchProperty(patient.EmployeeName, search)

                //Add more properties for search as needed
                );
            }



            var pagedPatients = _unitOfWork.employeetrining.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }




        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id, string employeeid, string EmplyeeName)
        {


            if (id > 0)
            {
          var model = _unitOfWork.employeetrining.GetById(id);
                model.DisplayTrining = _lookupServess.AllTrinng();
                return View(model);
            }
            else
            {
                var vewodel = new EmployeeTrininTVm();
                vewodel.DisplayTrining = _lookupServess.AllTrinng();

                vewodel.EmployeeName = EmplyeeName;
                vewodel.EmployeeId = employeeid;
                return View(vewodel);
            }

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EmployeeTrininTVm emp1)
        {
            //if (ModelState.IsValid)
            //{
                _unitOfWork. employeetrining.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));
            //}
            //return View(emp1);


        }

        // GET: EmployeeController/Delete/5


        // POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _unitOfWork.employeeWorkScheduleCurentWeek.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]


        //public IActionResult ADDrengeofshifts(IEnumerable<EmployeeWorkScheduleCurentWeekDayVm> employeeWorkScheduleCurentWeekDayVms)
        //{
        //     foreach(var  emp in employeeWorkScheduleCurentWeekDayVms)
        //    {

        //        _unitOfWork.employeeWorkScheduleCurentWeek.Save(emp);
        //    }


        //        return RedirectToAction(nameof(Gtbyemployeeid));

        //}
        /////}
        ///
    }
}
