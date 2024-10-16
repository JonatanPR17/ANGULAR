using Microsoft.AspNetCore.Mvc;
using vet_tomy.Models;
using vet_tomy_domain.Auth.Models;
using vet_tomy_domain.Auth.Repositories;
using vet_tomy_domain.Errors;

namespace vet_tomy.Controllers.Auth
{
    [ApiController]
    [Route("api/auth/authentication")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationRepository _auth;
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthenticationRepository auth, ILogger<AuthenticationController> logger)
        {
            _auth = auth;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponse> Login ([FromBody] LoginRequest body)
        {
            try
            {
            return Ok(_auth.Login(body));
            }
            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AuthenticationController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AuthenticationController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }


        [HttpPost]
        [Route("register")]
        public ActionResult<CustomResponse> Register([FromBody] RegisterRequest body)
        {
            try
            {
                _auth.Register(body);
                return Ok(new CustomResponse());
            }

            catch (MessageExeption ex)
            {
                _logger.LogError(
                    $"[AuthenticationController][ListAll]{ex.Message}\n {ex.StackTrace}");
                return StatusCode(500, new CustomResponse(error: true) { Message = ex.Message });
            }

            catch (Exception ex)
            {
                _logger.LogError(
                    $"[AuthenticationController][ListAll] {ex.Message}\n {ex.StackTrace} ");
                return StatusCode(500, new CustomResponse(error: true));
            }
        }
    }
}
