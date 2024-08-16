using Demo.Model;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers;

[Route("api/")]
[ApiController]
public class HealthCheckController : ControllerBase
{
    private readonly ILogger<HealthCheckController> _logger;


    public HealthCheckController(ILogger<HealthCheckController> logger)
    {
        _logger = logger;
    }

    [HttpGet("health")]
    public ApiResponse Ping()
    {
        return ApiResponse.Ok("pong");
    }
}