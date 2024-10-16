using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Errors;
using vet_tomy_domain.Store.Models;
using vet_tomy_domain.Store.Repositories;

namespace vet_tomy.Controllers.Pet
{
    [ApiController]
    [Route("/api/pet/branchs")]
    public class BranchController : ControllerBase
    {
        private readonly ILogger<BranchController> _logger;
        private readonly IPetRepository _petRepo;

        public BranchController(ILogger<BranchController> logger, IPetRepository petRepo) 
        {
            _logger = logger;
            _petRepo = petRepo;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<Branch>> ListAll()
        {
            try
            {
                List<Branch> branchs = _petRepo.Branch().GetAllInformation();
                return Ok(branchs);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpGet]
        [Route("{branch_id}")]
        public ActionResult<Branch> GetOnlyId([FromRoute] int branch_id)
        {
            try
            {
                Branch? branch = _petRepo.Branch().GetInformationId(branch_id);
                if (branch == null)
                {
                    return NotFound();
                }
                return Ok(branch);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Appointment> Create([FromBody] BranchBody body)
        {
            try
            {
                Branch branch = _petRepo.Branch().CreateNewInformation((Branch)body);
                return Ok(branch);
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpPut]
        [Route("{branch_id}")]
        public ActionResult<CustomResponse> Update([FromRoute] int branch_id, [FromBody] BranchBody body)
        {
            try
            {
                _petRepo.Branch().UpdateInformationId(branch_id, (Branch)body);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

        [HttpDelete]
        [Route("{branch_id}")]
        public ActionResult<CustomResponse> Delete([FromRoute] int branch_id)
        {
            try
            {
                _petRepo.Branch().DeleteInformationId(branch_id);
                return Ok(new CustomResponse());
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[BranchController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }

    }
}
