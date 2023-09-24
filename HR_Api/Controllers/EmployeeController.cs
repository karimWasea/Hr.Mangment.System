using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.IrepreatoryServess;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PagedList;



namespace HR_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public EmployeeController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public async Task<ActionResult<IPagedList<AplicatiouserDtoUpdate>>> GetPaginatedEmployee(int pageNumber = 1)
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
            var Employee = await _unitofwork.Employee.Search();

            // Use the PaginationHelper to get paginated data
            var Employees = _unitofwork.Employee.GetPagedData(Employee, pageNumber);

            return Ok(Employees);
        }

        [HttpGet("{id :alpha}")]
        public async Task<ActionResult<AplicatiouserDtoUpdate>> GetEmployeee(string id)
        {

            var product = await _unitofwork.Employee.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([ FromForm] AplicatiouserCreatDto productCreateDto )
        {









            var existingProduct =  await _unitofwork.Employee.Creat(productCreateDto);
            return Ok(existingProduct);
        }

        [HttpPut("CreateEmployee")]

        public async Task<IActionResult> UpdateGetEmployee([FromForm] AplicatiouserDtoUpdate updatedProductDto)
        {


            var existingProduct = await _unitofwork.Employee.Update(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id }")]

        public IActionResult DeleteEmployee(string id)
        {

            _unitofwork.Employee.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {

            var departments = _unitofwork.Employee.Search(searchTerm);

            return Ok(departments);
        }
    }



}


