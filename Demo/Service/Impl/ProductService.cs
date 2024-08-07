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

    public async Task<bool> DeleteProduct(int productId)
    {
        var test = _context.Products.ToList();
        var itemToRemove = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        if (itemToRemove != null) {
            _context.Products.Remove(itemToRemove);
            _context.SaveChanges();
            return true;
        }else{
            return false;
        }
    }

    public async Task<Product?> EditProduct(Product product)
    {
        var dbProduct = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
        if(dbProduct!=null){
            dbProduct.Name = product.Name;
            dbProduct.Description = product.Description;
            dbProduct.Price = product.Price;
            dbProduct.ImageURL  = product.ImageURL;
            dbProduct.IsRelease = product.IsRelease;
            _context.Products.Update(dbProduct);
            _context.SaveChanges();
            return dbProduct;
        }else{
            return null;
        }

    }

    public async Task<Product?> GetProduct(int productId)
    {
        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        return product;
    }
}