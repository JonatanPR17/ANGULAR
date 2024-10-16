using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Pet
{
    [ApiController]
    [Route("api/store/pets")]
    public class PetController : ControllerBase
    {
        private readonly ILogger<PetController> _logger;
        private readonly IPetRepository _petRepo;

        public PetController(ILogger<PetController> logger, IPetRepository petRepo) 
        {
            _logger = logger;
            _petRepo = petRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<vet_tomy_domain.Store.Models.Pet>> ListAll()
        {
            try
            {
                List<vet_tomy_domain.Store.Models.Pet> pets = _petRepo.Pet().GetAllInformation();
                return Ok(pets);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{pet_id}")]
        public ActionResult<vet_tomy_domain.Store.Models.Pet> GetOnlyId([FromRoute] int pet_id)
        {
            try
            {
                vet_tomy_domain.Store.Models.Pet? pet = _petRepo.Pet().GetInformationId(pet_id);
                if (pet == null)
                {
                    return NotFound();
                }
                return Ok(pet);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<MedicalHistory> Create([FromBody] PetBody body)
        {
            try
            {
                vet_tomy_domain.Store.Models.Pet pet = _petRepo.Pet().CreateNewInformation((vet_tomy_domain.Store.Models.Pet)body);
                return Ok(pet);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{pet_id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int pet_id, [FromBody] PetBody body)
        {
            try
            {
                _petRepo.Pet().UpdateInformationId(pet_id, (vet_tomy_domain.Store.Models.Pet)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{pet_id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int pet_id)
        {
            try
            {
                _petRepo.Pet().DeleteInformationId(pet_id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[PetController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
