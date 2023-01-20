using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface IItemRepository
    {
        List<ItemModel> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);
    }
}
