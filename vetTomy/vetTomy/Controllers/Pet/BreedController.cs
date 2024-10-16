using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Pet
{
    [ApiController]
    [Route("api/pet/breeds")]
    public class BreedController : ControllerBase
    {
        private readonly ILogger<BreedController> _logger;
        private readonly IPetRepository _petRepo;

        public BreedController(ILogger<BreedController> logger ,IPetRepository petRepo) 
        {
            _logger = logger;
            _petRepo = petRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Breed>> ListAll()
        {
            try
            {
                List<Breed> breeds = _petRepo.Breed().GetAllInformation();
                return Ok(breeds);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Breed> Create([FromBody] BreedBody body)
        {
            try
            {
                Breed breed = _petRepo.Breed().CreateNewInformation((Breed)body);
                return Ok(breed);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{breed_id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int breed_id, [FromBody] BreedBody body)
        {
            try
            {
                _petRepo.Breed().UpdateInformationId(breed_id, (Breed)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{breed_id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int breed_id)
        {
            try
            {
                _petRepo.Breed().DeleteInformationId(breed_id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BreedController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
