using PruebaTecnicaSitecV2.Data;
using PruebaTecnicaSitecV2.Interfaces;
using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly AppDbContext _db;
        public CategoryService(AppDbContext db)
        {
            _db = db;
        }
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public bool VerifyCategory(int id)
        {
            if (_db.Categories.Find(id) != null)
                return true;
            else
                return false;
        }
    }
}
