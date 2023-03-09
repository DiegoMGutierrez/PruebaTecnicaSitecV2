using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<Object> GetSales();
        IEnumerable<object> GetSalesByProduct(int id);
        IEnumerable<object> GetSalesByClient(int id);
        Sale PostSale(Sale body);
    }
}
