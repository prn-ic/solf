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
        [HttpGet("filterNumber/{number}")]
        public async Task<IEnumerable<OrderDto>> GetOrdersByNumber(string number)
        {
            return await _orderRepository.FilterByNumber(number);
        }
        [HttpGet("filterDate/{startTime}+{endTime}")]
        public async Task<IEnumerable<OrderDto>> GetOrdersByDate(DateTime startTime, DateTime endTime)
        {
            return await _orderRepository.FilterByDate(startTime, endTime);
        }
        [HttpGet("filterProvider/{providerId}")]
        public async Task<IEnumerable<OrderDto>> GetOrdersByProvider(int id)
        {
            return await _orderRepository.FilterByProvider(id);
        }
        [HttpPut("{id}")]
        public async Task<OrderDto> UpdateOrder([FromRoute] int id, [FromBody] Order order)
        {
            return await _orderRepository.UpdateOrder(id, order);
        }
        [HttpDelete("{id}")]
        public async Task<ResultDto> DeleteOrder(int id)
        {
            return await _orderRepository.DeleteOrder(id);
        }
    }
}