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
    public class TriningController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public TriningController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList<TrainingDTO>> GetPaginatedTrining(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.trining.Search(  );

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.trining.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<TrainingDTO> Gettrining(int id)
        {

            var product = _unitofwork.trining.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<TrainingDTO> CreateDepartment([FromForm] TrainingDTO productCreateDto)
        {









            var existingProduct = _unitofwork.trining.Save(productCreateDto);
            return CreatedAtAction(nameof(Gettrining), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut]
        public ActionResult<TrainingDTO> Updatetrining( [FromForm] TrainingDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.trining.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletetrining(int id)
        {

            _unitofwork.trining.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
          
         var departments=  _unitofwork.trining.Search(searchTerm);

            return Ok(departments);
        }
    }



}
