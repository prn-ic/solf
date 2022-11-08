using solfordTestCase.Database.Services;
using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;
using solfordTestCase.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace solfordTestCase.Database.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private AppDbContext _context;
        private MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.CreateMap<Order, OrderDto>();
            configuration.CreateMap<Result, ResultDto>();
        }
        );
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<OrderDto> CreateOrder(Order order)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            
            return mapper.Map<OrderDto>(order);
        }

        public async Task<ResultDto> DeleteOrder(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            Order? order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _context.Orders.Remove(order!);

            await _context.SaveChangesAsync();
            return mapper.Map<ResultDto>(new Result { Success = true });
        }

        public async Task<IEnumerable<OrderDto>> FilterByDate(DateTime startDate, DateTime endDate)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<Order> orders = await _context.Orders
                .AsNoTracking()
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .ToListAsync();

            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<IEnumerable<OrderDto>> FilterByNumber(string orderNumber)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<Order> orders = await _context.Orders
                .AsNoTracking()
                .Where(x => x.Number == orderNumber)
                .ToListAsync();

            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<IEnumerable<OrderDto>> FilterByProvider(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<Order> orders = await _context.Orders
                .AsNoTracking()
                .Where(x => x.ProviderId == id)
                .ToListAsync();

            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> GetOrder(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            Order? order = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<OrderDto>(order);
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<Order> orders = await _context.Orders.AsNoTracking().ToListAsync();

            return mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<OrderDto> UpdateOrder(int id, Order order)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            Order? oldOrder = await _context.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            order.Id = id;
            
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();

            return mapper.Map<OrderDto>(order);
        }
    }
}