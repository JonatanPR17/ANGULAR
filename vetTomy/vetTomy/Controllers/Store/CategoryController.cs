using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("api/store/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IStoreRepository _storeRepo;

        public CategoryController(ILogger<CategoryController> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Category>> ListAll()
        {
            try
            {
                List<Category> categories = _storeRepo.Category().GetAllInformation();
                return Ok(categories);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Category> Create([FromBody] CategoryBody body)
        {
            try
            {
                Category category = _storeRepo.Category().CreateNewInformation( (Category)body);
                return Ok(category);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                 return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int id, [FromBody] CategoryBody body)
        {
            try
            {
                _storeRepo.Category().UpdateInformationId( id, (Category)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int id)
        {
            try
            {
                _storeRepo.Category().DeleteInformationId(id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[CategoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


    }
}
