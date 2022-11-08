using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;

namespace solfordTestCase.Domain.Repository
{
    public interface IOrderRepository
    {
        Task<OrderDto> CreateOrder(Order order);
        Task<IEnumerable<OrderDto>> GetOrders();
        Task<OrderDto> GetOrder(int id);
        Task<OrderDto> UpdateOrder(int id, Order order);
        Task<bool> DeleteOrder(int id);
    }
}