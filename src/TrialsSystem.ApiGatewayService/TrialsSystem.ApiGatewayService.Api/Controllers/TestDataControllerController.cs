using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrialsSystem.ApiGatewayService.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestDataController : ControllerBase
    {
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "AuthorizedUser")]
        public async Task<IActionResult> Get()
        {

            return Ok(new { name = "Test", message = "authorize" });
        }
    }
}
