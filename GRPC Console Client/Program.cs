using Grpc.Net.Client;
using GRPC_Product_Service;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7026");
var client = new Products.ProductsClient(channel);
var reply = client.GetAllProducts(new Empty());
for (int i = 0; i < reply.Products.Count; i++)
{
    Console.WriteLine(reply.Products[i].ProductID);
    Console.WriteLine(reply.Products[i].Name);
    Console.WriteLine(reply.Products[i].Price);
    Console.WriteLine(reply.Products[i].CategoryID);
    Console.WriteLine(reply.Products[i].OnSale);
    Console.WriteLine(reply.Products[i].StockLevel);
    Console.WriteLine();
    Console.WriteLine();
}
///Get Product
//var reply = client.GetProduct(new ProductId { Id = 1 });
//Console.WriteLine(reply.ProductID);
//Console.WriteLine(reply.Name);
//Console.WriteLine(reply.Price);
//Console.WriteLine(reply.CategoryID);
//Console.WriteLine(reply.OnSale);
//Console.WriteLine(reply.StockLevel);
//Console.WriteLine();
//Console.WriteLine("============================================================");

Console.ReadLine();




