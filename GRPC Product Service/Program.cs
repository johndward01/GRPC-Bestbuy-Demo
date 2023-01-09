using BestBuyProductRepo.Interfaces;
using BestBuyProductRepo.Models;
using BestBuyProductService.Repositories;
using GRPC_Product_Service.Services;
using MySql.Data.MySqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddTransient<IProductRepository, ProductRepo>();
builder.Services.AddScoped<IDbConnection>((s) =>
{
    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("bestbuy"));
    conn.Open();
    return conn;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client." +
" To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.MapGet("/", () => "Hello Mock Bestbuy API!");
app.MapGet("/GetAllProducts", (IProductRepository productRepo) => productRepo.GetAllProducts());

app.MapPost("/InsertProduct", (IProductRepository productRepo, Product product) =>
{
    int lastProductId = productRepo.GetAllProducts().LastOrDefault().ProductID;
    product.ProductID = ++lastProductId;
    productRepo.InsertProduct(product);
});

app.MapPut("/UpdateProduct/{id:int}", (IProductRepository productRepo, Product inputProduct, int id) =>
{
    var productToUpdate = productRepo.GetProduct(id);
    productToUpdate.Name = inputProduct.Name;
    productToUpdate.Price = inputProduct.Price;
    productToUpdate.CategoryID = inputProduct.CategoryID;
    productToUpdate.OnSale = inputProduct.OnSale;
    productToUpdate.StockLevel = inputProduct.StockLevel;
    productRepo.UpdateProduct(productToUpdate);
});

app.MapDelete("/DeleteProduct/{id:int}", (IProductRepository productRepo, int id) =>
{
    productRepo.DeleteProduct(new Product() { ProductID = id });
});


app.Run();
