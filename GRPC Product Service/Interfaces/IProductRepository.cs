using BestBuyProductRepo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyProductRepo.Interfaces;
public interface IProductRepository
{
    public Product GetProduct(int id);
    public IEnumerable<Product> GetAllProducts();
    public void UpdateProduct(Product product);
    public void InsertProduct(Product productToInsert);
    public void DeleteProduct(Product product);
}
