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
        Task<ResultDto> DeleteOrder(int id);
        Task<IEnumerable<OrderDto>> FilterByDate(DateTime startDate, DateTime endDate);
        Task<IEnumerable<OrderDto>> FilterByNumber(string orderNumber);
        Task<IEnumerable<OrderDto>> FilterByProvider(int id);
    }
}