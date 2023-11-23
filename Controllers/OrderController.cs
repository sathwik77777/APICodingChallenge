using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIChallenge.Services;
using APIChallenge.Entities;
using Microsoft.AspNetCore.Authorization;

namespace APIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService orderService;

        public OrderController(OrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpPost, Route("PlaceOrder")]
        [Authorize(Roles = "User")]
        public IActionResult PlaceOrder(Order order)
        {
            try
            {
                order.OrderId = Guid.NewGuid(); 
                orderService.PlaceOrder(order);
                return StatusCode(200, order);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet,Route("GetOrderById")]
        [Authorize(Roles ="Admin")]
        public IActionResult GetOrders()   
        {
            try
            {
                List<Order> orders = orderService.GetOrders();
                return StatusCode(200, orders);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }



        }
        [HttpGet, Route("GetOrdersByProduct/{productId}")]
        [Authorize(Roles = "Admin")]
        [Authorize(Roles = "Supplier")]
        public IActionResult GetOrdersByProductId(int productId)
        {
            try
            {
                List<Order> orders = orderService.GetOrdersByProductId(productId);
                return StatusCode(200, orders);
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }
    }
}
