using Grpc.Net.Client;
using GRPC_Console_Client;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7026");
var client = new Products.ProductsClient(channel);

var id = 1;
for (int i = 0; i < 900; i++)
{
    //Thread.Sleep(1000);

    var reply = client.GetProduct(new GetProductRequest()
    {
        ProductID = id++,
    });
    Console.WriteLine(reply.ProductID);
    Console.WriteLine(reply.Name);
    Console.WriteLine(reply.Price);
    Console.WriteLine(reply.CategoryID);
    Console.WriteLine(reply.OnSale);
    Console.WriteLine(reply.StockLevel);
    Console.WriteLine();
    Console.WriteLine("============================================================");

}
Console.ReadLine();




