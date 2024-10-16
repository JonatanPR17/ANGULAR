using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Pet
{
    [ApiController]
    [Route("api/pet/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly ILogger<AppointmentController> _logger;
        private readonly IPetRepository _petRepo;

        public AppointmentController(ILogger<AppointmentController> logger, IPetRepository petRepo) 
        {
            _logger = logger;
            _petRepo = petRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Appointment>> ListAll()
        {
            try
            {
                List<Appointment> appointments = _petRepo.Appointment().GetAllInformation();
                return Ok(appointments);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{appointment_id}")]
        public ActionResult<Appointment> GetOnlyId([FromRoute] int appointment_id)
        {
            try
            {
                Appointment? appointment = _petRepo.Appointment().GetInformationId(appointment_id);
                if (appointment == null)
                {
                    return NotFound();
                }
                return Ok(appointment);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Appointment> Create([FromBody] AppointmentBody body)
        {
            try
            {
                Appointment appointment = _petRepo.Appointment().CreateNewInformation((Appointment)body);
                return Ok(appointment);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{appointment_id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int appointment_id, [FromBody] AppointmentBody body)
        {
            try
            {
                _petRepo.Appointment().UpdateInformationId(appointment_id, (Appointment)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{appointment_id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int appointment_id)
        {
            try
            {
                _petRepo.Appointment().DeleteInformationId(appointment_id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AppointmentController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


    }
}
