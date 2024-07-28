using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;

namespace Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;

    private readonly IProductService _service;

   public ProductController(IProductService service,ILogger<ProductController> logger)
   {
      _service = service;
      _logger = logger;
    }
   

   
    [HttpPost("QueryProducts")]
    public async Task<ApiResponse> GetAllProducts(QueryCondition query)
    {
        var data =  await _service.QueryProduct(query);
        return ApiResponse.Ok(data);
    }

    [HttpPost("AddProduct")]
    public async Task<ApiResponse> AddProduct(Product product)
    {
        var result = await _service.AddProduct(product);
        return ApiResponse.Ok(result);
    }
}

