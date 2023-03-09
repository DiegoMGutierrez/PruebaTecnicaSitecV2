using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Interfaces
{
    public interface IProductService
    {
        IEnumerable<object> GetProducts();
        Product GetProductById(int id);
        Product PostProduct(Product body);
        Product PutProduct(int id, Product body);
        Product DeleteProduct(int id);
        Product PatchStock(int id, int NewStock);
        Product PatchPrice(int id, decimal NewPrice);
        void PutMany(List<Product> body);
    }
}
