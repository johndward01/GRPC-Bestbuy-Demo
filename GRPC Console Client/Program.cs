using Grpc.Net.Client;
using GRPC_Product_Service;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7026");
var client = new Products.ProductsClient(channel);
Product reply = null;
string input = "";

while (input != "exit")
{
    var number = 0;
    Console.WriteLine("1: Get All Products");
    Console.WriteLine("2: Get Product");
    Console.WriteLine("3: Update Product");
    Console.WriteLine("4: Delete Product");
    number = int.Parse(Console.ReadLine());

    switch (number)
    {

        case 1:
            reply = client.GetAllProducts(Google.Protobuf.Empty);
            break;
        case 2:
            reply = client.GetProduct(new ProductId() { Id = 1 });
            break;
        default:
            break;
    }
}

Console.WriteLine(reply.ProductID);
Console.WriteLine(reply.Name);
Console.WriteLine(reply.Price);
Console.WriteLine(reply.CategoryID);
Console.WriteLine(reply.OnSale);
Console.WriteLine(reply.StockLevel);
Console.WriteLine();
Console.WriteLine("============================================================");

Console.ReadLine();




