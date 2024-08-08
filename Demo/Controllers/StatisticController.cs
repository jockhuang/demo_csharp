using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticController : ControllerBase
{
    private readonly ILogger<StatisticController> _logger;

    private readonly IStatisticService _service;

   public StatisticController(IStatisticService service,ILogger<StatisticController> logger)
   {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ApiResponse> GetHomeData()
    {
        var result = await _service.GetHomeData();
        if(result!=null){
            return ApiResponse.Ok(result);
        }else{
            return ApiResponse.Failed("Item not found!");
        }
        
    }
}