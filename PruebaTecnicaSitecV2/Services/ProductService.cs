using EFCore.BulkExtensions;
using PruebaTecnicaSitecV2.Data;
using PruebaTecnicaSitecV2.Interfaces;
using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Services
{
    public class ProductService:IProductService
    {
        private readonly AppDbContext _db;
        public ProductService(AppDbContext db)
        {
            _db = db;
        }
        public IEnumerable<object> GetProducts()
        {
            /*var result = _db.Products.Join(_db.Categories, product => product.CategoryId, category => category.CategoryId
            , (product, category) => new { product, category }).ToList();*/
            var result = from product in _db.Products   
                         join category in _db.Categories
                         on product.CategoryId equals category.CategoryId
                         select new { product ,category};
                        
            return (result);
        }
        public Product GetProductById(int id)
        {
            return (_db.Products.Find(id));
        }

        public Product PostProduct(Product body)
        {
            _db.Products.Add(body);
            _db.SaveChanges();
            return body;
        }
        public Product PutProduct(int id, Product body)
        {
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb != null)
            {
                ProductFromDb.ProductName = body.ProductName;
                ProductFromDb.ProductDescription = body.ProductDescription;
                ProductFromDb.ProductStock = body.ProductStock;
                ProductFromDb.ProductPrice = body.ProductPrice;
                ProductFromDb.CategoryId = body.CategoryId;

                _db.Update(ProductFromDb);
                _db.SaveChanges();
                return (ProductFromDb);
            }
            else return null;
        }

        public void PutMany(List<Product> body)
        {
            _db.BulkUpdate(body);
        }
        public Product DeleteProduct(int id)
        {
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb != null)
            {
                _db.Remove(ProductFromDb);
                _db.SaveChanges();
                return (ProductFromDb);
            }
            else return null;
        }
        public Product PatchStock(int id, int NewStock)
        {
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb != null)
            {
                ProductFromDb.ProductStock = NewStock;
                _db.Update(ProductFromDb);
                _db.SaveChanges();
                return ProductFromDb;
            }
            else return null;
        }
        public Product PatchPrice(int id, decimal NewPrice)
        {
            var ProductFromDb = _db.Products.Find(id);
            if (ProductFromDb != null)
            {
                ProductFromDb.ProductPrice = NewPrice;
                _db.Update(ProductFromDb);
                _db.SaveChanges();
                return ProductFromDb;
            }
            else return null;
        }
        
        

    }
}
