using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSitecV2.Data;
using PruebaTecnicaSitecV2.Interfaces;
using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Services
{
    public class SaleService:ISaleService
    {
        private readonly AppDbContext _db;
        public SaleService(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<object> GetSales()
        {
            
            var result = _db.Sales.Include(x => x.ProductSales).Join(_db.Clients,
                sale => sale.ClientId, client => client.ClientId, (sale, client) => new { sale, client }).ToList();
            return result;
        }
        public IEnumerable<object> GetSalesByClient(int id)
        {
            var result = _db.Sales.Where(x => x.ClientId == id ).Include(x => x.ProductSales).Join(_db.Clients,
                sale => sale.ClientId, client => client.ClientId, (sale, client) => new {sale, client }).ToList();
            return result;
        }

        public IEnumerable<object> GetSalesByProduct(int id)
        {
            
            var result = _db.Sales.Include(x => x.ProductSales).Where(y=>y.ProductSales.Any(x=>x.ProductId == id)).Join(_db.Clients,
                sale => sale.ClientId, client => client.ClientId, (sale, client) => new { sale, client }).ToList();
            return (result);
        }
        public Sale PostSale(Sale body)
        {
            _db.Sales.Add(body);
            _db.SaveChanges();
            return (body);
        }
    }
}
