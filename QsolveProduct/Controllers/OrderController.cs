using Contract;
using Entities;
using Entities.DTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QsolveProduct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private RepositoryContext _context; 
        //private readonly ILogger _logger;

        public OrderController(IRepositoryWrapper repository, RepositoryContext context)
        {
            _context = context;
            _repository = repository;
            // _logger = logger;
        }

        [HttpGet]
        [Route("GetOrder")]
        public async Task<IActionResult> Get()
        {
            var orderItems = _repository.Orders.GetAll();

            var result = from orders in _context.Orders
                         join orderItem in _context.OrderItems on orders.OrderId equals orderItem.OrderId
                         join product in _context.Products on orderItem.ProductId equals product.ProductId
                         select new
                         {
                             orders.OrderId,
                             orders.CustomerId,
                             orders.OrderDateTime,
                             orders.TotalPrice,
                             orderItem.OrderItemId,
                             orderItem.OrderQuantity,
                             orderItem.Price,
                             product.ProductId,
                             product.ProductName,
                             product.Description,
                         };

            if (orderItems.Exception != null || orderItems.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            //return Ok(orderItems.Result);
            return Ok(result);

        }

        [HttpGet]
        [Route("GetOrderById")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {


            var order = _repository.Orders.GetById(id);
            if (order.Result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return Ok(order.Result);

        }

        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> Post(OrdersDTO order)
        {
            try
            {
                var orderEntity = new Orders
                {
                    CustomerId = order.CustomerId,
                    OrderDateTime = order.OrderDateTime,
                    TotalPrice = order.TotalPrice,
                };
                _repository.Orders.Add(orderEntity);
                _repository.Save();

                List<OrderItem> data = new List<OrderItem>();

               /*foreach (var orderItem in order.Items)
               {
                    var addOrderItems = new OrderItem
                    {
                        OrderId = orderEntity.OrderId,
                        ProductId = orderItem.ProductId,
                        OrderQuantity = orderItem.OrderQuantity,
                        Price = orderItem.Price,
                        OrdersOrderId = orderEntity.OrderId,

                    };
                    data.Add(addOrderItems);
               }*/

                 var orderItemEntity = new OrderItem
                 {
                      OrderId = orderEntity.OrderId,
                      ProductId = order.Items.ProductId,
                      OrderQuantity = order.Items.OrderQuantity,
                      Price = order.Items.Price,
                      OrdersOrderId = orderEntity.OrderId,
                 };

                _repository.OrderItem.Add(orderItemEntity);
                _repository.Save();


                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }


        }

        [HttpPut]
        [Route("UpdateOrder")]
        public async Task<IActionResult> Put(OrdersDTO order)
        {
            try
            {
                var orderEntity = new Orders
                {
                    OrderId= order.OrderId,
                    CustomerId = order.CustomerId,
                    OrderDateTime = order.OrderDateTime,
                    TotalPrice = order.TotalPrice,
                };
                _repository.Orders.Update(orderEntity);
                _repository.SaveChanges();

                var orderItemEntity = new OrderItem
                {
                    OrderItemId = order.Items.OrderItemId,
                    OrderId = order.Items.OrderId,
                    ProductId = order.Items.ProductId,
                    OrderQuantity = order.Items.OrderQuantity,
                    Price = order.Items.Price,
                    OrdersOrderId = order.Items.OrderId,
                };

                _repository.OrderItem.Update(orderItemEntity);
                _repository.SaveChanges();


                return Ok("Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex);
            }
            /*try
            {
                _repository.Orders.Update(order);
                _repository.SaveChanges();
                return Ok("Updated Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status304NotModified, ex);
            }*/

        }

        [HttpDelete]
        [Route("DeleteOrder")]
        public async Task<IActionResult> Delete(Guid id)
        {

            if (id == Guid.Empty)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            try
            {
                var orderDelete = await _repository.Orders.GetById(id);
                _repository.Orders.Remove(orderDelete);
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
