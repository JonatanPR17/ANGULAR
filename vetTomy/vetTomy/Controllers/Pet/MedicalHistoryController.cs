using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Pet
{
    [ApiController]
    [Route("api/pet/medical_history")]
    public class MedicalHistoryController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IPetRepository _petRepo;

        public MedicalHistoryController(ILogger<MedicalHistoryController> logger, IPetRepository petRepo)
        {
            _logger = logger;
            _petRepo = petRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<MedicalHistory>> ListAll()
        {
            try
            {
                List<MedicalHistory> medicalHistories = _petRepo.MedicalHistory().GetAllInformation();
                return Ok(medicalHistories);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{medicalHistory_id}")]
        public ActionResult<Appointment> GetOnlyId([FromRoute] int medicalHistory_id)
        {
            try
            {
                MedicalHistory? medicalHistory = _petRepo.MedicalHistory().GetInformationId(medicalHistory_id);
                if (medicalHistory == null)
                {
                    return NotFound();
                }
                return Ok(medicalHistory);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<MedicalHistory> Create([FromBody] MedicalHistoryBody body)
        {
            try
            {
                MedicalHistory medicalHistory = _petRepo.MedicalHistory().CreateNewInformation((MedicalHistory)body);
                return Ok(medicalHistory);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{medicalHistory_id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int medicalHistory_id, [FromBody] MedicalHistoryBody body)
        {
            try
            {
                _petRepo.MedicalHistory().UpdateInformationId(medicalHistory_id, (MedicalHistory)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{medicalHistory_id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int medicalHistory_id)
        {
            try
            {
                _petRepo.MedicalHistory().DeleteInformationId(medicalHistory_id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[MedicalHistoryController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
