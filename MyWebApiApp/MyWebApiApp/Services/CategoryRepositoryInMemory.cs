using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class CategoryRepositoryInMemory : ICategoryRepository
    {
        static List<CategoryVM> categories = new List<CategoryVM>
        {
            new CategoryVM{Id = 1, Name = "Tivi"},
            new CategoryVM{Id = 2, Name = "Tủ lạnh"},
            new CategoryVM{Id = 3, Name = "Điều hòa"},
            new CategoryVM{Id = 4, Name = "Máy giặt"},
        };

        public CategoryVM Add(CateModel category)
        {
            var _category = new CategoryVM
            {
                Id = categories.Max(c => c.Id) + 1,
                Name = category.Name,
            };
            categories.Add(_category);
            return _category;
        }

        public void Delete(int id)
{
            var _category = categories.SingleOrDefault(c => c.Id == id);
            categories.Remove(_category);
        }

        public List<CategoryVM> GetAll()
        {
            return categories;
        }

        public CategoryVM GetById(int id)
        {
            return categories.SingleOrDefault(c => c.Id == id);
        }

        public void Update(CategoryVM category)
        {
            var _category = categories.SingleOrDefault(c => c.Id == category.Id);
            if (_category != null)
            {
                _category.Name = category.Name;
            }
        }
    }
}
