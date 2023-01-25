using GRPC_Product_Service.Interfaces;
using Dapper;
using System.Data;

namespace GRPC_Product_Service.Repositories;

public class ProductRepo : IProductRepository
{
    private readonly IDbConnection _conn;

    public ProductRepo(IDbConnection conn)
    {
        _conn = conn;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products;");
    }

    public Product GetProduct(int id)
    {
        return _conn.QuerySingleOrDefault<Product>("SELECT * FROM products WHERE ProductID = @id",
            new { id });
    }

    public void UpdateProduct(Product product)
    {
        _conn.Execute("UPDATE products SET Name = @name, Price = @price, CategoryID = @catID, OnSale = @onsale, StockLevel = @stocklevel WHERE ProductID = @id;",
            new { name = product.Name, price = product.Price, catID = product.CategoryID, onsale = product.OnSale, stocklevel = product.StockLevel, id = product.ProductID });
    }

    public void InsertProduct(Product productToInsert)
    {
        _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryID);",
            new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
    }    

    public void DeleteProduct(Product product)
    {
        _conn.Execute("DELETE FROM Reviews WHERE ProductID = @id;", new { id = product.ProductID });
        _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
        _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
    }
}

