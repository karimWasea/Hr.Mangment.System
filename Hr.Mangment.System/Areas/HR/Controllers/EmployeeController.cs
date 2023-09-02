﻿using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]

    public class EmployeeController : Controller
    {
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public EmployeeController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        public  IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.Employee.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Employee.SearchProperty(patient.Adress, search) ||
                     _unitOfWork.Employee.SearchProperty(patient.Email, search) ||
                    _unitOfWork.Employee.SearchProperty(patient.UserName, search, StringComparison.OrdinalIgnoreCase) 
                // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.Employee.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

        // GET: EmployeeController/Details/5
        public ActionResult Details(string id)
        {
            return View(_unitOfWork.Employee.GetById(id));
        }



        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(string id)
        {
            ViewBag.alldep = _lookupServess.DepartmitAll();
            ViewBag.GEnder = _lookupServess.GEnder();
            if (id != null)
            {
                var model = await _unitOfWork.Employee.GetById(id);
                return View(model);
            }
            else
            {
                return View();
            }
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( EmployeeVM emp1 )
        {
            //if (ModelState.IsValid)
            //{
             await   _unitOfWork.Employee.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));
            //}
            //  return View(emp1); 

            
        }

        // GET: EmployeeController/Delete/5
     

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
          await  _unitOfWork.Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
