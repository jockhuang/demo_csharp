namespace Demo.Service.Impl;

using Demo.Model;
using Microsoft.EntityFrameworkCore;
using Demo.Service;

public class ProductService : IProductService
{
    private readonly DemoDbContext _context;

    public ProductService(DemoDbContext context)
    {
        _context = context;
    }
    public async Task<PaginatedData<Product>> QueryProduct(QueryCondition query)
    {
        
        var dbQuery =  _context.Products.Where(c=>c.Id>0);
        if(!string.IsNullOrWhiteSpace(query.Search)){
            dbQuery = dbQuery.Where(c=>c.Name.Contains(query.Search, StringComparison.OrdinalIgnoreCase));
        }
        

        var count = await dbQuery.CountAsync();
        if(!string.IsNullOrWhiteSpace(query.OrderBy)) {
            dbQuery=dbQuery.OrderBy(query.OrderBy,query.IsDesc);
        }
        var products = await dbQuery
            .Skip((query.PageIndex - 1) * query.PageSize)
            .Take(query.PageSize)
            .ToListAsync();
        return new PaginatedData<Product>(products,query.PageIndex,count,query.PageSize);
    }

    public async Task<Product> AddProduct(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return product;
    }
}