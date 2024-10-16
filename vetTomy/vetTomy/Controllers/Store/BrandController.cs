using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("/api/store/brands")]
    public class BrandController : ControllerBase
    {
        public readonly ILogger<BrandController> _logger;
        public readonly IStoreRepository _storeRepo;

        public BrandController(ILogger<BrandController> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;  
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Brand>> ListAll()
        {
            try
            {
                List<Brand> brands = _storeRepo.Brand().GetAllInformation();
                return Ok(brands);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message});
            }

            catch (Exception ex) 
            {
                _logger.LogError(
                    $"[BrandController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Brand> GetOnlyId([FromRoute] int id) 
        {
            try
            {
                Brand? brand = _storeRepo.Brand().GetInformationId(id);
                if (brand == null)
                {
                    return NotFound();
                }
                return Ok(brand);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Brand> Create([FromBody] BrandBody body)
        {
            try
            {
                Brand brand = _storeRepo.Brand().CreateNewInformation( (Brand) body);
                return Ok(brand);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{brand_id}")]
        public ActionResult<CustomResponse> Update( [FromRoute] int brand_id, [FromBody] BrandBody body ) 
        {
            try
            {
                _storeRepo.Brand().UpdateInformationId(brand_id, (Brand)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{brand_id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int brand_id) 
        {
            try
            {
                _storeRepo.Brand().DeleteInformationId(brand_id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BrandController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
