using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public CategoryVM Add(CateModel category)
        {
            var _category = new Category { Name = category.Name };
            _context.Add(_category);
            _context.SaveChanges();
            return new CategoryVM { Id = _category.Id, Name = _category.Name };
        }

        public void Delete(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges();
            }
        }

        public List<CategoryVM> GetAll()
        {
            var categories = _context.Categories.Select(c => new CategoryVM { Id = c.Id, Name = c.Name });
            return categories.ToList();
        }

        public CategoryVM GetById(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
                return new CategoryVM { Id = category.Id, Name = category.Name };
            return null;
        }

        public void Update(CategoryVM category)
        {
            var _category = _context.Categories.SingleOrDefault(c => c.Id == category.Id);
            if (_category != null)
            {
                category.Name = _category.Name;
                _context.SaveChanges();
            }
        }
    }
}
