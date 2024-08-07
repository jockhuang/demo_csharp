using Demo.Model;

namespace Demo.Service;

public interface IProductService{
    public Task<PaginatedData<Product>> QueryProduct(QueryCondition query);
    
    public Task<Product> AddProduct(Product product);

    public Task<bool> DeleteProduct(int productId);

    public Task<Product?> EditProduct(Product product);

    public Task<Product?> GetProduct(int productId);

}