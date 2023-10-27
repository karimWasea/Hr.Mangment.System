using HR_Api.Dtos;
using HR_Api.IrepreatoryServess;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PagedList;

using static HR_Api.Dtos.VacarionDTOAdd;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionSalaryController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public TransactionSalaryController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
       
        [HttpGet]
        public ActionResult<IPagedList<SalaryTransactionTO>> GetPaginatedsalarytransaction(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.salarytransaction_Api.Search(  );

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.salarytransaction_Api.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<SalaryTransactionTO> Getsalarytransaction(int id)
        {

            var product = _unitofwork.salarytransaction_Api.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }
        [HttpGet("Getsalarytransactionemployee")]
        public ActionResult<SalaryTransactionTO> Getsalarytransactionemployee(string employeeid)
        {

            var product = _unitofwork.salarytransaction_Api.GetByEmployeeIdALLtrantionforemployee(employeeid);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateSalarytransaction([FromForm] SalaryTransactionTOAdd vacationDTO)
        {
            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, return a BadRequest response with the validation errors
                return BadRequest(ModelState);
            }

            try
            {
                // Save the vacation if it's valid and return a CreatedAtAction response
                var existingVacation = _unitofwork.salarytransaction_Api.Add(vacationDTO);
                return CreatedAtAction(nameof(Getsalarytransaction), new { id = existingVacation.Id }, existingVacation);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while creating the vacation.");
            }
        }



        [HttpPut("{id}")]
        public IActionResult UpdateSalarytransaction(int id, [FromForm] SalaryTransactionTO updatedProductDto)
        {
            if (id != updatedProductDto.Id)
            {
                // Return a BadRequest response if the provided ID doesn't match the ID in the data
                return BadRequest("ID in the URL does not match the ID in the data.");
            }

            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, return a BadRequest response with the validation errors
                return BadRequest(ModelState);
            }

            try
            {
                var existingProduct = _unitofwork.salarytransaction_Api.Update(updatedProductDto);

                if (existingProduct == null)
                {
                    // Return a NotFound response if the resource with the given ID is not found
                    return NotFound("Resource not found.");
                }

                // Return a 204 No Content response to indicate a successful update
                return NoContent();
            }
            catch (Exception ex)
            {
                // Handle other exceptions, log them, and return an appropriate response
                // For example, you can return a 500 Internal Server Error
                // Log the exception for debugging or monitoring purposes
                // Log.Error(ex, "Error updating vacation");
                return StatusCode(500, "An error occurred while updating the vacation.");
            }
        }

        //[HttpPost]
        //public ActionResult<SalaryTransactionTO> Createsalarytransaction([FromForm] SalaryTransactionTO productCreateDto)
        //{









        //    var existingProduct = _unitofwork.salarytransaction_Api.Save(productCreateDto);
        //    return CreatedAtAction(nameof(Getsalarytransaction), new { id = existingProduct.Id }, existingProduct);
        //}

        //[HttpPut("{id}")]
        //public ActionResult<SalaryTransactionTO> Updatesalarytransaction(int id, [FromForm] SalaryTransactionTO updatedProductDto)
        //{


        //    var existingProduct = _unitofwork.salarytransaction_Api.Save(updatedProductDto);
        //    return Ok(existingProduct);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Deletesalarytransaction(int id)
        //{

        //    _unitofwork.salarytransaction_Api.Delete(id);
        //    return NoContent();
        //}


        //[HttpGet("search")]
        //public IActionResult Search([FromQuery] string searchTerm)
        //{

        // var departments=  _unitofwork.salarytransaction_Api.Search(searchTerm);

        //    return Ok(departments);
        //}
    }



}
