using Microsoft.AspNetCore.Mvc;
using solfordTestCase.Domain.Dto;
using solfordTestCase.Domain.Models;
using solfordTestCase.Domain.Repository;

namespace solfordTestCase.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private IProviderRepository _providerRepository;
        private ILogger<ProviderController> _logger;
        public ProviderController(IProviderRepository providerRepository,
            ILogger<ProviderController> logger
        )
        {
            _providerRepository = providerRepository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<ProviderDto> CreateProvider([FromBody] Provider provider)
        {
            return await _providerRepository.CreateProvider(provider);
        }
        [HttpGet]
        public async Task<IEnumerable<ProviderDto>> GetProviders()
        {
            return await _providerRepository.GetProviders();
        }
        [HttpGet("{id}")]
        public async Task<ProviderDto> GetProvider(int id)
        {
            return await _providerRepository.GetProvider(id);
        }
        [HttpDelete("{id}")]
        public async Task<bool> DeleteProvider(int id)
        {
            return await _providerRepository.DeleteProvider(id);
        }
    }
}