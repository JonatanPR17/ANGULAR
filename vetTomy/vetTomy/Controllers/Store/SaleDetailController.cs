using Microsoft.AspNetCore.Mvc;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("api/store/sale_details")]
    public class SaleDetailController : ControllerBase
    {
        private readonly ILogger<SaleDetailController> _logger;
        private readonly IStoreRepository _storeRepo;

        public SaleDetailController(ILogger<SaleDetailController> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;
        }


    }
}
