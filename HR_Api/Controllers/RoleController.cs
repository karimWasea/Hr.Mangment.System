using apistudy.Models.Entityies;

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
    public class RoleController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public RoleController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public async Task<ActionResult<IPagedList<SystemRolsDtoUpdate>>> GetPaginatedRole(int pageNumber = 1)
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
            var Employee = await _unitofwork.systemRole_Api.Search();

            // Use the PaginationHelper to get paginated data
            var Employees = _unitofwork.systemRole_Api.GetPagedData(Employee, pageNumber);

            return Ok(Employees);
        }

        [HttpGet("GetRoles")]
        public async Task<ActionResult<SystemRolsDtoUpdate>> GetRoles(string id)
        {

            var product = await _unitofwork.systemRole_Api.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([ FromForm] SystemRolsDtoCreate productCreateDto )
        {









            var existingProduct =  await _unitofwork.systemRole_Api.Creat(productCreateDto);
            return Ok(existingProduct);
        }

        [HttpPut]

        public async Task<IActionResult> UpdateRole([FromForm] SystemRolsDtoUpdate updatedProductDto)
        {


            var existingProduct = await _unitofwork.systemRole_Api.Update(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete]

        public IActionResult DeleteEmployee(string id)
        {

            _unitofwork.systemRole_Api.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {

            var departments = _unitofwork.systemRole_Api.Search(searchTerm);

            return Ok(departments);
        }
    }



}


