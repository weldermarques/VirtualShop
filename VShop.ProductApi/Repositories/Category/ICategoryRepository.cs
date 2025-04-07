using CategoryEntity = VShop.ProductApi.Models.Category;

namespace VShop.ProductApi.Repositories.Category;

public interface ICategoryRepository : IBase<CategoryEntity>
{
    Task<IEnumerable<CategoryEntity>> GetCategoriesProducts();
}
