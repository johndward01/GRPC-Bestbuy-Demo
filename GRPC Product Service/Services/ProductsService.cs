using BestBuyProductRepo.Interfaces;
using Grpc.Core;
using System.Data;

namespace GRPC_Product_Service.Services;

public class ProductsService : Products.ProductsBase
{
    private readonly IProductRepository _repository;

    public ProductsService(IProductRepository repository)
    {
        _repository = repository;
    }

    public override Task<GetProductReply> GetProduct(GetProductRequest request, ServerCallContext context)
    {
        var product = _repository.GetProduct(request.ProductID);
        if (product != null)
        {
            return Task.FromResult(new GetProductReply
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
            return Task.FromResult(new GetProductReply
            {
                ProductID = 100,
                Name = "Oops",
                Price = 100.99,
                CategoryID = 10,
                OnSale = 0,
                StockLevel = 100,
            });
        }        
    }
}
