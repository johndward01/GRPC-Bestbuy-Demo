namespace GRPC_Product_Service.Interfaces;

public interface IProductRepository
{
    public Product GetProduct(int id);
    public IEnumerable<Product> GetAllProducts();
    public void UpdateProduct(Product product);
    public void InsertProduct(Product productToInsert);
    public void DeleteProduct(Product product);
}
