using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly DemoDbContext _context;

   public ProductController(DemoDbContext context,ILogger<ProductController> logger)
   {
      _context = context;
      _logger = logger;
    }
   

   
    [HttpGet("GetAllProducts")]
    public async Task<ApiResponse> GetAllProducts()
    {
        var data =  await _context.Products.ToListAsync();
        return ApiResponse.Ok(data);
    }

    [HttpPost("AddProduct")]
    public async Task<ApiResponse> AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return ApiResponse.Ok(product);
    }
}

