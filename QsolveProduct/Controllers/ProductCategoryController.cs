using Contract;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace QsolveProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        //private readonly ILogger _logger;

        public ProductCategoryController(IRepositoryWrapper repository)
        {
            _repository = repository;
            // _logger = logger;
        }

        [HttpGet]
        [Route("GetProductCategory")]
        public async Task<IActionResult> Get()
        {
            var weather = _repository.ProductCategory.GetAll();

            if (weather.Exception != null || weather.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(weather.Result);

        }

        [HttpGet]
        [Route("GetProductCategoryById")]
        public async Task<IActionResult> GetProductCategoryById(Guid id)
        {


            var weather = _repository.ProductCategory.GetById(id);
            if (weather.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(weather.Result);

        }

        [HttpPost]
        [Route("AddProductCategory")]
        public async Task<IActionResult> Post(ProductCategoryDTO productCategory)
        {
            try
            {
                var mapProductCategory = new ProductCategory
                {
                    ProductCategoryName = productCategory.ProductCategoryName,
                };
                _repository.ProductCategory.Add(mapProductCategory);
                _repository.Save();
                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }


        }

        [HttpPut]
        [Route("UpdateProductCategory")]
        public async Task<IActionResult> Put(ProductCategoryDTO productCategory)
        {
            try
            {
                var mapProductCategory = new ProductCategory
                {
                    ProductCategoryId = productCategory.ProductCategoryId,
                    ProductCategoryName = productCategory.ProductCategoryName,
                };
                _repository.ProductCategory.Update(mapProductCategory);
                _repository.SaveChanges();
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, ex);
            }

        }

        [HttpDelete]
        [Route("DeleteProductCategory")]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == Guid.Empty)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            try
            {
                var productCategoryToDelete = await _repository.ProductCategory.GetById(id);
                _repository.ProductCategory.Remove(productCategoryToDelete);
                _repository.SaveChanges();
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }

        }
    }
}
