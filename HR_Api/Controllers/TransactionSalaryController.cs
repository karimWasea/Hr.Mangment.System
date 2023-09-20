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
        public ActionResult<SalaryTransactionTO> Createsalarytransaction([FromForm] SalaryTransactionTO productCreateDto)
        {









            var existingProduct = _unitofwork.salarytransaction_Api.Save(productCreateDto);
            return CreatedAtAction(nameof(Getsalarytransaction), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<SalaryTransactionTO> Updatesalarytransaction(int id, [FromForm] SalaryTransactionTO updatedProductDto)
        {


            var existingProduct = _unitofwork.salarytransaction_Api.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletesalarytransaction(int id)
        {

            _unitofwork.salarytransaction_Api.Delete(id);
            return NoContent();
        }


        //[HttpGet("search")]
        //public IActionResult Search([FromQuery] string searchTerm)
        //{
          
        // var departments=  _unitofwork.salarytransaction_Api.Search(searchTerm);

        //    return Ok(departments);
        //}
    }



}
