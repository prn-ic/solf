using solfordTestCase.Database.Services;
using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;
using solfordTestCase.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace solfordTestCase.Database.Repository
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private AppDbContext _context;
        private MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.CreateMap<OrderItem, OrderItemDto>();
            configuration.CreateMap<Result, ResultDto>();
        }
        );
        public OrderItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<OrderItemDto> CreateOrderItem(OrderItem orderItem)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            await _context.OrderItems.AddAsync(orderItem);
            await _context.SaveChangesAsync();

            return mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<ResultDto> DeleteOrderItem(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            OrderItem? orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _context.OrderItems.Remove(orderItem!);

            return mapper.Map<ResultDto>(new Result { Success = true });
        }

        public async Task<IEnumerable<OrderItemDto>> FilterByName(string orderItemName)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<OrderItem> orderItems = await _context.OrderItems
                .AsNoTracking()
                .Where(x => x.Name == orderItemName)
                .ToListAsync();

            return mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
        }

        public async Task<IEnumerable<OrderItemDto>> FilterByUnit(string orderItemUnit)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<OrderItem> orderItems = await _context.OrderItems
                .AsNoTracking()
                .Where(x => x.Unit == orderItemUnit)
                .ToListAsync();

            return mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> GetOrderItem(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            OrderItem? orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<IEnumerable<OrderItemDto>> GetOrderItems()
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<OrderItem> orderItems = await _context.OrderItems.AsNoTracking().ToListAsync();

            return mapper.Map<IEnumerable<OrderItemDto>>(orderItems);
        }

        public async Task<OrderItemDto> UpdateOrderItem(int id, OrderItem orderItem)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            OrderItem? item = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            orderItem!.Id = id;
            
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();

            return mapper.Map<OrderItemDto>(orderItem);
        }

    }
}