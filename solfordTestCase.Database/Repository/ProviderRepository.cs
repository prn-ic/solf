using solfordTestCase.Database.Services;
using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;
using solfordTestCase.Domain.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace solfordTestCase.Database.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private AppDbContext _context;
        private MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
        {
            configuration.CreateMap<Result, ResultDto>();
            configuration.CreateMap<Provider, ProviderDto>();
        }
        );
        public ProviderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ProviderDto> CreateProvider(Provider provider)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();

            await _context.Providers.AddAsync(provider);
            await _context.SaveChangesAsync();

            return mapper.Map<ProviderDto>(provider);
        }

        public async Task<ResultDto> DeleteProvider(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            Provider? provider = await _context.Providers
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Providers.Remove(provider!);

            await _context.SaveChangesAsync();
            return mapper.Map<ResultDto>(new Result { Success = true} );
        }

        public async Task<IEnumerable<ProviderDto>> FilterByName(string name)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<Provider>? provider = await _context.Providers
                .AsNoTracking()
                .Where(x => x.Name == name)
                .ToListAsync();

            return mapper.Map<IEnumerable<ProviderDto>>(provider);
        }

        public async Task<ProviderDto> GetProvider(int id)
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            Provider? provider = await _context.Providers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return mapper.Map<ProviderDto>(provider);
        }

        public async Task<IEnumerable<ProviderDto>> GetProviders()
        {
            IMapper? mapper = mapperConfiguration.CreateMapper();
            IEnumerable<Provider> providers = await _context.Providers.AsNoTracking().ToListAsync();

            return mapper.Map<IEnumerable<ProviderDto>>(providers);
        }
    }
}