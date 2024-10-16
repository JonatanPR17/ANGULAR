using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("api/store/images")]
    public class ImageController : ControllerBase
    {
        private readonly ILogger<ImageController> _logger;
        private readonly IStoreRepository _storeRepo;

        public ImageController(ILogger<ImageController> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;
        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Image> GetOnlyId([FromRoute] int id)
        {
            try
            {
                Image? image = _storeRepo.Image().GetInformationId(id);
                if (image == null)
                {
                    return NotFound();
                }
                return Ok(image);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Image> Create([FromBody] ImageBody body)
        {
            try
            {
                Image image = _storeRepo.Image().CreateNewInformation((Image)body);
                return Ok(image);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CustomResponse> Update( [FromRoute] int id, [FromBody] ImageBody body)
        {
            try
            {
                _storeRepo.Image().UpdateInformationId( id, (Image)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int id)
        {
            try
            {
                _storeRepo.Image().DeleteInformationId(id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ImageController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
