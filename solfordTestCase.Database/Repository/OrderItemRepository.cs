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
            configuration.CreateMap<OrderItem, OrderItemDto>() 
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

        public async Task<bool> DeleteOrderItem(int id)
        {
            OrderItem? orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _context.OrderItems.Remove(orderItem!);

            return true;
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

        public async Task<OrderItemDto> UpdateOrderItemName(int id, string name)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            OrderItem? orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            orderItem!.Name = name;
            
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();

            return mapper.Map<OrderItemDto>(orderItem);
        }

        public async Task<OrderItemDto> UpdateOrderItemUnit(int id, string unitName)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            OrderItem? orderItem = await _context.OrderItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            orderItem!.Unit = unitName;
            
            _context.OrderItems.Update(orderItem);
            await _context.SaveChangesAsync();

            return mapper.Map<OrderItemDto>(orderItem);
        }
    }
}