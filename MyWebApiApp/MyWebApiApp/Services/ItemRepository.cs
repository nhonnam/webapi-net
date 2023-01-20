using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class ItemRepository : IItemRepository
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 5;

        public ItemRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<ItemModel> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            var allProducts = _context.Items.Include(i => i.Category).AsQueryable();

            #region Filtering
            if (!string.IsNullOrEmpty(search))
                allProducts = _context.Items.Where(i => i.Name.Contains(search));
            if (from.HasValue)           
                allProducts = allProducts.Where(i => i.UnitPrice >= from);           
            if (to.HasValue)           
                allProducts = allProducts.Where(i => i.UnitPrice <= to);
            #endregion

            #region Sorting
            // Default sort by Name
            allProducts = allProducts.OrderBy(i => i.Name);
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "name_desc":
                        allProducts = allProducts.OrderByDescending(i => i.Name);
                        break;
                    case "price_asc":
                        allProducts = allProducts.OrderBy(i => i.UnitPrice);
                        break;
                    case "price_desc":
                        allProducts = allProducts.OrderByDescending(i => i.UnitPrice);
                        break;
                }
            }
            #endregion

            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion

            //var result = allProducts.Select(i => new ItemModel
            //{
            //    Id = i.Id,
            //    Name = i.Name,
            //    UnitPrice = i.UnitPrice,
            //    Category = i.Category.Name
            //});

            //return result.ToList();

            var result = PaginatedList<Data.Item>.Create(allProducts, page, PAGE_SIZE);
            return result.Select(i => new ItemModel
            {
                Id = i.Id,
                Name = i.Name,
                UnitPrice = i.UnitPrice,
                Category = i.Category.Name
            }).ToList();
        }
    }
}
