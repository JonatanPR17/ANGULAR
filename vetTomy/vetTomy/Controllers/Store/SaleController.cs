using Microsoft.AspNetCore.Mvc;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("api/store/sales")]
    public class SaleController : ControllerBase
    {
        private readonly ILogger<SaleController> _logger;
        private readonly IStoreRepository _storeRepo;

        public SaleController(ILogger<SaleController> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;
        }

    }
}
