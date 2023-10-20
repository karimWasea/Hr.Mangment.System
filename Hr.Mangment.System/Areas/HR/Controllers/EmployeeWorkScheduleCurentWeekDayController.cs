using DataAcess.layes;

using HR.Utailites;
using HR.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ReprestoryServess;

using System.Collections.Generic;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
    [Authorize(Roles = SystemRols.SuperAdmin)]

    public class EmployeeWorkScheduleCurentWeekDayController : BaseController
    {
        public EmployeeWorkScheduleCurentWeekDayController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {

        }

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.employeeWorkScheduleCurentWeek.GetAll();
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



        public IActionResult Gtbyemployeeid(int? page, string search, string employeeid)
        {
            var model = _unitOfWork.employeeWorkScheduleCurentWeek.GetAllShiftByemployeeId(employeeid);
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




        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id, string employeeid, string EmplyeeName)
        {


            if (id > 0)
            {
                EmployeeWorkScheduleCurentWeekDayVm? model = _unitOfWork.employeeWorkScheduleCurentWeek.GetById(id);
                model.DisplayShiftlist = _lookupServess.Selectallshiofts();
                return View(model);
            }
            else
            {
                var vewodel = new EmployeeWorkScheduleCurentWeekDayVm();
                vewodel.DisplayShiftlist = _lookupServess.Selectallshiofts();

                vewodel.EmployeeName = EmplyeeName;
                vewodel.EmployeeId = employeeid;
                return View(vewodel);
            }

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(EmployeeWorkScheduleCurentWeekDayVm emp1)
        {
            //if (ModelState.IsValid)
            //{
                _unitOfWork.employeeWorkScheduleCurentWeek.Save(emp1);
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
