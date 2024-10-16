using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Store
{
    [ApiController]
    [Route("api/store/reviews")]
    public class ReviewController : ControllerBase
    {
        private readonly ILogger<ReviewController> _logger;
        private readonly IStoreRepository _storeRepo;

        public ReviewController(ILogger<ReviewController> logger, IStoreRepository storeRepo)
        {
            _logger = logger;
            _storeRepo = storeRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Review>> ListAll()
        {
            try
            {
                List<Review> review = _storeRepo.Review().GetAllInformation();
                return Ok(review);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Review> GetOnlyId([FromRoute] int id)
        {
            try
            {
                Review? review = _storeRepo.Review().GetInformationId(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Review> Create([FromBody] ReviewBody body)
        {
            try
            {
                Review review = _storeRepo.Review().CreateNewInformation((Review)body);
                return Ok(review);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult<CustomResponse> Update( [FromRoute] int id, [FromBody] ReviewBody body)
        {
            try
            {
                _storeRepo.Review().UpdateInformationId( id ,(Review)body );
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int id)
        {
            try
            {
                _storeRepo.Review().DeleteInformationId(id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[ReviewController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
