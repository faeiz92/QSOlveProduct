using Contract;
using Entities.Models;
using Entities.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QsolveProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        public ProductController(IRepositoryWrapper repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> Get()
        {
            var weather = _repository.Product.GetAll();

            if (weather.Exception != null || weather.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(weather.Result);

        }

        [HttpGet]
        [Route("GetProductCategoryById")]
        public async Task<IActionResult> GetProductById(Guid id)
        {


            var weather = _repository.Product.GetById(id);
            if (weather.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(weather.Result);

        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> Post(ProductDTO product)
        {
            var productEntity = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                ProductCategoryId = product.ProductCategoryId,
            };

            try
            {
                _repository.Product.Add(productEntity);
                _repository.Save();
                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }


        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> Put(ProductDTO product)
        {
            try
            {
                var productEntity = new Product
                {
                    ProductName = product.ProductName,
                    Description = product.Description,
                    ProductCategoryId = product.ProductCategoryId,
                };
                _repository.Product.Update(productEntity);
                _repository.SaveChanges();
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, ex);
            }

        }

        [HttpDelete]
        [Route("DeleteProduct")]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == Guid.Empty)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            try
            {
                var productToDelete = await _repository.Product.GetById(id);
                _repository.Product.Remove(productToDelete);
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
