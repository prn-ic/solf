using Microsoft.AspNetCore.Mvc;
using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;
using solfordTestCase.Domain.Repository;

namespace solfordTestCase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private IOrderRepository _orderRepository;
        private ILogger<OrderController> _logger;
        public OrderController(IOrderRepository orderRepository,
            ILogger<OrderController> logger
        )
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<OrderDto> CreateOrder([FromBody] Order order)
        {
            return await _orderRepository.CreateOrder(order);
        }
        [HttpGet]
        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            return await _orderRepository.GetOrders();
        }
        [HttpGet("{id}")]
        public async Task<OrderDto> GetOrder(int id)
        {
            return await _orderRepository.GetOrder(id);
        }
        [HttpPut("{id}")]
        public async Task<OrderDto> UpdateOrder([FromRoute] int id, [FromBody] Order order)
        {
            return await _orderRepository.UpdateOrder(id, order);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteOrder(int id)
        {
            return await _orderRepository.DeleteOrder(id);
        }
    }
}