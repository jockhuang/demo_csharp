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

    [HttpDelete("RemoveSubscription")]
    public async Task<ApiResponse> DeleteProduct(string email)
    {
        var result = await _service.DeleteMail(email);
       if(result){
            return ApiResponse.Ok(result);
        }else{
            // for safety reason, always return true
            return ApiResponse.Ok(true);
        }
    }
}

