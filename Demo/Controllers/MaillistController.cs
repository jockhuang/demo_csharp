using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailListController : ControllerBase
{
    private readonly ILogger<MailListController> _logger;

    private readonly IMailListService _service;

    public MailListController(IMailListService service, ILogger<MailListController> logger)
    {
      _service = service;
      _logger = logger;
    }
   

   
    [HttpPost("GetMailList")]
    public async Task<ApiResponse> GetMailList(QueryCondition query)
    {
        var data =  await _service.GetAllMailList(query);
        return ApiResponse.Ok(data);
    }

    [HttpPost("AddSubscription")]
    public async Task<ApiResponse> AddSubscription(MailList mail)
    {
        var data =  await _service.AddMail(mail);
        return ApiResponse.Ok(mail);
    }
}

