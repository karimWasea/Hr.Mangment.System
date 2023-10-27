using DataAcess.layes;

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
    public class TriningeMPLoyeeController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public TriningeMPLoyeeController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpPost]
        public IActionResult CreateVaction([FromForm] EmployeeTriningDTOAdd vacationDTO)
        {
            if (!ModelState.IsValid)
            {
                // If ModelState is not valid, return a BadRequest response with the validation errors
                return BadRequest(ModelState);
            }

            try
            {
                // Save the vacation if it's valid and return a CreatedAtAction response
                var existingVacation = _unitofwork.TriningEmpoyee.Add(vacationDTO);
                return CreatedAtAction(nameof(GetEmployeeTrining), new { id = existingVacation.Id }, existingVacation);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while creating the vacation.");
            }
        }



        [HttpPut("{id}")]
        public IActionResult UpdateVacation(int id, [FromForm] EmployeeTriningDTO updatedProductDto)
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
                var existingProduct = _unitofwork.TriningEmpoyee.Update(updatedProductDto);

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

        [HttpGet]
        public ActionResult<IPagedList< EmployeeTriningDTO>> GetPaginatedEmployeeTrining(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.TriningEmpoyee.GetAll();

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.TriningEmpoyee.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeTriningDTO> GetEmployeeTrining(int id)
        {

            var product = _unitofwork.TriningEmpoyee.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

      

        [HttpDelete("{id}")]
        public IActionResult DeleteDeviceEmployee(int id)
        {

            _unitofwork.TriningEmpoyee.Delete(id);
            return NoContent();
        }


        [HttpGet("GEtallforthiemployee")]
        public IActionResult GEtallforthiemployee([FromQuery] string employeeid)
        {
          
         var departments=  _unitofwork.TriningEmpoyee.EmployeeTRining(employeeid);

            return Ok(departments);
        }
    }



}
