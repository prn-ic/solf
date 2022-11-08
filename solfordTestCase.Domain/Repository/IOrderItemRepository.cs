using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;

namespace solfordTestCase.Domain.Repository
{
    public interface IOrderItemRepository
    {
        Task<OrderItemDto> CreateOrderItem(OrderItem orderItem);
        Task<IEnumerable<OrderItemDto>> GetOrderItems();
        Task<OrderItemDto> GetOrderItem(int id);
        Task<OrderItemDto> UpdateOrderItemName(int id, string name);
        Task<OrderItemDto> UpdateOrderItemUnit(int id, string unitName);
        Task<bool> DeleteOrderItem(int id);
    }
}