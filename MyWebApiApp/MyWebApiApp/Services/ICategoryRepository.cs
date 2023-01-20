using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface ICategoryRepository
    {
        List<CategoryVM> GetAll();
        CategoryVM GetById(int id);
        CategoryVM Add(CateModel category);
        void Update(CategoryVM category);
        void Delete(int id);
    }
}
