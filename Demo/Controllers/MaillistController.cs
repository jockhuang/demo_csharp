using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MaillistController : ControllerBase
{
    private readonly ILogger<MaillistController> _logger;

    private readonly DemoDbContext _context;

   public MaillistController(DemoDbContext context,ILogger<MaillistController> logger)
   {
      _context = context;
      _logger = logger;
    }
   

   
    [HttpGet("GetMailList")]
    public async Task<ApiResponse> GetMailList()
    {
        var data =  await _context.Maillists.ToListAsync();
        return ApiResponse.Ok(data);
    }

    [HttpPost("AddSubscription")]
    public async Task<ApiResponse> AddSubscription(Maillist mail)
    {
        _context.Maillists.Add(mail);
        await _context.SaveChangesAsync();
        return ApiResponse.Ok(mail);
    }
}

