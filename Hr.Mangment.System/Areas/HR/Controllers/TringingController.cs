﻿using DataAcess.layes;

using HR.Utailites;
using HR.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
    [Authorize(Roles = SystemRols.SuperAdmin)]


    public class TringingController : BaseController
    {
        

          public TringingController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {

        }


        public IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.Trining.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                model = model.Where(patient =>
                  _unitOfWork.Trining.SearchProperty(patient.TrainingName, search) 

                );
            }

            var pagedPatients = _unitOfWork.Deparment.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

      


        public async Task<IActionResult> Save(int id)
        {
            

            if (id >0)
            {
              var model = _unitOfWork.Trining.GetById(id);
                model.Mangers = _lookupServess.EmployeeAll();
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
        public async Task<IActionResult> Save( Trainingvm emp1 )
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Trining.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));
            }
            return View(emp1);


        }

        // GET: EmployeeController/Delete/5
     

        // POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int  id)
        {
          _unitOfWork.Trining.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
