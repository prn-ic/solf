using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;

namespace solfordTestCase.Domain.Repository
{
    public interface IOrderItemRepository
    {
        Task<OrderItemDto> CreateOrderItem(OrderItem orderItem);
        Task<IEnumerable<OrderItemDto>> GetOrderItems();
        Task<OrderItemDto> GetOrderItem(int id);
        Task<OrderItemDto> UpdateOrderItem(int id, OrderItem orderItem);
        Task<ResultDto> DeleteOrderItem(int id);
        Task<IEnumerable<OrderItemDto>> FilterByName(string orderItemName);
        Task<IEnumerable<OrderItemDto>> FilterByUnit(string orderItemUnit);
    }
}