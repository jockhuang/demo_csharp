using Demo.Model;
using Demo.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


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
    public async Task<ApiResponse> QueryProducts(QueryCondition query)
    {
        var json = JsonSerializer.Serialize(query);
        _logger.LogInformation("query condition:{}",json);
        var data =  await _service.QueryProduct(query);
        return ApiResponse.Ok(data);
    }

    [HttpPost("AddProduct")]
    public async Task<ApiResponse> AddProduct(Product product)
    {
        var result = await _service.AddProduct(product);
        return ApiResponse.Ok(result);
    }

    [HttpDelete("{productId}")]
    public async Task<ApiResponse> DeleteProduct(int productId)
    {
        var result = await _service.DeleteProduct(productId);
       if(result){
            return ApiResponse.Ok(result);
        }else{
            return ApiResponse.Failed("Item not found!");
        }
    }

    [HttpPut("{productId}")]
    public async Task<ApiResponse> EditProduct(int productId,Product product)
    {
        product.Id = productId;
        var result = await _service.EditProduct(product);
        if(result!=null){
            return ApiResponse.Ok(result);
        }else{
            return ApiResponse.Failed("Item not found!");
        }
    }

    [HttpGet("{productId}")]
    public async Task<ApiResponse> GetProduct(int productId)
    {
        var result = await _service.GetProduct(productId);
        if(result!=null){
            return ApiResponse.Ok(result);
        }else{
            return ApiResponse.Failed("Item not found!");
        }
        
    }
}

