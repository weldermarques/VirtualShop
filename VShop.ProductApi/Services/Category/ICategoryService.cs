using VShop.ProductApi.DTOs;

namespace VShop.ProductApi.Services.Category;

public interface ICategoryService : IBaseService<CategoryDto>
{
    Task<IEnumerable<CategoryDto>> GetCategoriesProducts();
}
