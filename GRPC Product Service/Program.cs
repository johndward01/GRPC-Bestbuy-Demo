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
app.MapGrpcService<ProductsService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client." +
" To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");





app.Run();
