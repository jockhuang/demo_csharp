using Demo.Model;

namespace Demo.Service;

public interface IProductService{
    public Task<PaginatedData<Product>> QueryProduct(QueryCondition query);
    public Task<Product> AddProduct(Product product);
}