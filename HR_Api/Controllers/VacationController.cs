using HR_Api.Dtos;
using HR_Api.IrepreatoryServess;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PagedList;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  VacationController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public VacationController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList<VacarionDTO>> GetPaginatedVacatio(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.Vaction.Search(  );

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.Vaction.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<VacarionDTO> Getvacation(int id)
        {

            var product = _unitofwork.Vaction.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<VacarionDTO> CreateVaction([FromForm] VacarionDTO productCreateDto)
        {









            var existingProduct = _unitofwork.Vaction.Save(productCreateDto);
            return CreatedAtAction(nameof(Getvacation), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut]
        public ActionResult<DevicDTO> UpdateVacation( [FromForm] VacarionDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.Vaction.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletevacation(int id)
        {

            _unitofwork.Vaction.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
          
         var departments=  _unitofwork.Device.Search(searchTerm);

            return Ok(departments);
        }
    }



}
