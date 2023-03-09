using PruebaTecnicaSitecV2.Models;

namespace PruebaTecnicaSitecV2.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        bool VerifyCategory(int id);
    }
}
