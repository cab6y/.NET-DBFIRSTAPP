
using Application.Test;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers.ServicesController.Test
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestAppService _testAppService;
        public TestController(ITestAppService testAppService)
        {
            _testAppService = testAppService;
        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(string name)
        {
            if (name == null)
            {
                return BadRequest("Invalid data.");
            }
            var result = await _testAppService.CreateAsync(name);
            if (result)
            {
                return Ok("Test created successfully.");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating test.");
            }
        }
    }
}
