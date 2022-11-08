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
        [HttpGet("{id}")]
        public async Task<OrderItemDto> GetOrderItem(int id)
        {
            return await _orderItemRepository.GetOrderItem(id);
        }
        [HttpPut("{id}+{name}")]
        public async Task<OrderItemDto> UpdateOrderItemName(int id, string name)
        {
            return await _orderItemRepository.UpdateOrderItemName(id, name);
        }
        [HttpPut("{id}+{unit}")]
        public async Task<OrderItemDto> UpdateOrderItemUnit(int id, string unitName)
        {
            return await _orderItemRepository.UpdateOrderItemUnit(id, unitName);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeletOrderItem(int id)
        {
            return await _orderItemRepository.DeleteOrderItem(id);
        }
    }
}