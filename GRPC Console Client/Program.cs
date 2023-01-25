using Grpc.Net.Client;
using GRPC_Product_Service;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7026");
var client = new Products.ProductsClient(channel);

#region Get Product
//var reply = client.GetProduct(new ProductId { Id = 1 });
//Console.WriteLine(reply.ProductID);
//Console.WriteLine(reply.Name);
//Console.WriteLine(reply.Price);
//Console.WriteLine(reply.CategoryID);
//Console.WriteLine(reply.OnSale);
//Console.WriteLine(reply.StockLevel);
//Console.WriteLine();
//Console.WriteLine("============================================================");
//Console.WriteLine();
#endregion

#region Get All Products
//var reply = client.GetAllProducts(new Empty());
//for (int i = 0; i < reply.Products.Count; i++)
//{
//    Console.WriteLine(reply.Products[i].ProductID);
//    Console.WriteLine(reply.Products[i].Name);
//    Console.WriteLine(reply.Products[i].Price);
//    Console.WriteLine(reply.Products[i].CategoryID);
//    Console.WriteLine(reply.Products[i].OnSale);
//    Console.WriteLine(reply.Products[i].StockLevel);
//    Console.WriteLine();
//    Console.WriteLine();
//}
#endregion

#region Update Product
//var productToUpdate = client.GetProduct(new ProductId() { Id = 945 });
//productToUpdate.Name = "UPDATED V2 via GRPC_Console_Client";
//productToUpdate.Price = 100.00;
//productToUpdate.CategoryID = 10;
//productToUpdate.OnSale = 0;
//productToUpdate.StockLevel = 100;

//var reply = client.UpdateProduct(productToUpdate);
//var updatedProduct = client.GetProduct(new ProductId() { Id = 945 });
//Console.WriteLine(updatedProduct.ProductID);
//Console.WriteLine(updatedProduct.Name);
//Console.WriteLine(updatedProduct.Price);
//Console.WriteLine(updatedProduct.CategoryID);
//Console.WriteLine(updatedProduct.OnSale);
//Console.WriteLine(updatedProduct.StockLevel);
//Console.WriteLine();
//Console.WriteLine("============================================================");
#endregion

#region Insert Product
//var product = new Product()
//{
//    Name = "GRPC INSERT PRODUCT TEST",
//    Price = 1.99,
//    CategoryID = 10,
//    OnSale = 0,
//    StockLevel = 100,
//};
//var reply = client.InsertProduct(product);
//var products = client.GetAllProducts(new Empty());
//for (int i = 0; i < products.Products.Count; i++)
//{
//    Console.WriteLine(products.Products[i].ProductID);
//    Console.WriteLine(products.Products[i].Name);
//    Console.WriteLine(products.Products[i].Price);
//    Console.WriteLine(products.Products[i].CategoryID);
//    Console.WriteLine(products.Products[i].OnSale);
//    Console.WriteLine(products.Products[i].StockLevel);
//    Console.WriteLine();
//    Console.WriteLine();
//}
#endregion

#region Delete Product

#endregion


Console.WriteLine("End");
Console.ReadLine();


