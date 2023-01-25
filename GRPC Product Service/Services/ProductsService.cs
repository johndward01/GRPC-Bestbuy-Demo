using Grpc.Core;
using GRPC_Product_Service.Interfaces;
using System.Data;

namespace GRPC_Product_Service.Services;

public class ProductsService : Products.ProductsBase
{
    private readonly IProductRepository _repository;
    private static readonly Empty _empty = new();

    public ProductsService(IProductRepository repository)
    {
        _repository = repository;
    }

    public override Task<Product> GetProduct(ProductId id, ServerCallContext context)
    {
        var product = _repository.GetProduct(id.Id);
        if (product != null)
        {
            return Task.FromResult(new Product
            {
                ProductID = product.ProductID,
                Name = product.Name,
                Price = product.Price,
                CategoryID = product.CategoryID,
                OnSale = product.OnSale,
                StockLevel = product.StockLevel,
            });
        }
        else
        {
            return Task.FromResult(new Product
            {
                ProductID = 0,
                Name = "NULL",
                Price = 0,
                CategoryID = 0,
                OnSale = 0,
                StockLevel = 0,
            });
        }        
    }

    public override Task<ProductList> GetAllProducts(Empty empty, ServerCallContext context)
    {
        var productList = new ProductList();
        var products = _repository.GetAllProducts();
        
        productList.Products.AddRange(products.Select(p => new GRPC_Product_Service.Product()
        {
            ProductID = p.ProductID,
            Name = p.Name,
            Price = p.Price,
            CategoryID = p.CategoryID,
            OnSale = p.OnSale,
            StockLevel = p.StockLevel,
        })); 

        return Task.FromResult(productList);
    }

    public override Task<Empty> UpdateProduct(Product product, ServerCallContext context)
    {
        _repository.UpdateProduct(new Product()
        {
            ProductID = product.ProductID,
            Name = product.Name,
            Price = product.Price,
            CategoryID = product.CategoryID,
            OnSale = product.OnSale,
            StockLevel = product.StockLevel,
        });
        return Task.FromResult(_empty);
    }

    public override Task<Empty> InsertProduct(Product product, ServerCallContext context)
    {
        _repository.InsertProduct(product);
        return Task.FromResult(new Empty());
    }
}
