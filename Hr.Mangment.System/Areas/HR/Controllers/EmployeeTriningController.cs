﻿using DataAcess.layes;

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


    public class EmployeeTriningController : BaseController
    {
        public EmployeeTriningController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {

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
            var model = _unitOfWork.employeetrining.GetAllTrainingsByemployeeId(employeeid);
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
            emp1.DisplayTrining = _lookupServess.AllTrinng();

            if (ModelState.IsValid)
            {
                _unitOfWork. employeetrining.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(GetAssinedTring), new
                {
                    page = (int?)null,
                    search =
                                  (string)null,
                    Employeeid = emp1.EmployeeId
                });
            }
        return View(emp1);


    }

        // GET: EmployeeController/Delete/5


        // POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
           var employeeid= _unitOfWork.employeeWorkScheduleCurentWeek.GetById(id);
            _unitOfWork.employeeWorkScheduleCurentWeek.Delete(id);
            TempData["Message"] = $" Deleted!";
            TempData["MessageType"] = "Delete";
            return RedirectToAction(nameof(GetAssinedTring), new
            {
                page = (int?)null,
                search =
                               (string)null,
                Employeeid = employeeid
            });
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
