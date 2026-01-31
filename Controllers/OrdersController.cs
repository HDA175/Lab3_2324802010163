using Lab3_2324802010163.Application.DTOs;
using Lab3_2324802010163.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab3_2324802010163.API.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDto dto)
        {
            await _orderService.CreateOrderAsync(dto);
            return Ok("Order created successfully.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderByIdAsync(id);

            if (order == null)
                return NotFound();

            return Ok(order);
        }
    }
}
