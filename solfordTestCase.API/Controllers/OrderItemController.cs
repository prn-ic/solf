using Microsoft.AspNetCore.Mvc;
using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;
using solfordTestCase.Domain.Repository;

namespace solfordTestCase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : ControllerBase
    {
        private IOrderItemRepository _orderItemRepository;
        private ILogger<OrderItemController> _logger;
        public OrderItemController(IOrderItemRepository orderItemRepository,
            ILogger<OrderItemController> logger
        )
        {
            _orderItemRepository = orderItemRepository;
            _logger = logger; 
        }
        [HttpPost]
        public async Task<OrderItemDto> CreateOrderItem(OrderItem orderItem)
        {
            return await _orderItemRepository.CreateOrderItem(orderItem);
        }
        [HttpGet]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItems()
        {
            return await _orderItemRepository.GetOrderItems();
        }
        [HttpGet("filterName/{name}")]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByName(string name)
        {
            return await _orderItemRepository.FilterByName(name);
        }
        [HttpGet("filterUnit/{unit}")]
        public async Task<IEnumerable<OrderItemDto>> GetOrderItemsByUnit(string unit)
        {
            return await _orderItemRepository.FilterByUnit(unit);
        }
        [HttpGet("{id}")]
        public async Task<OrderItemDto> GetOrderItem(int id)
        {
            return await _orderItemRepository.GetOrderItem(id);
        }
        [HttpPut("{id}")]
        public async Task<OrderItemDto> UpdateOrderItem(int id, OrderItem orderItem)
        {
            return await _orderItemRepository.UpdateOrderItem(id, orderItem);
        }
        [HttpDelete("{id}")]
        public async Task<ResultDto> DeletOrderItem(int id)
        {
            return await _orderItemRepository.DeleteOrderItem(id);
        }
    }
}