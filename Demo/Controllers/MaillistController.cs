using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MailListController : ControllerBase
{
    private readonly ILogger<MailListController> _logger;

    private readonly DemoDbContext _context;

   public MailListController(DemoDbContext context,ILogger<MailListController> logger)
   {
      _context = context;
      _logger = logger;
    }
   

   
    [HttpGet("GetMailList")]
    public async Task<ApiResponse> GetMailList()
    {
        var data =  await _context.MailList.ToListAsync();
        return ApiResponse.Ok(data);
    }

    [HttpPost("AddSubscription")]
    public async Task<ApiResponse> AddSubscription(MailList mail)
    {
        _context.MailList.Add(mail);
        await _context.SaveChangesAsync();
        return ApiResponse.Ok(mail);
    }
}

