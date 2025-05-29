using VShop.ProductApi.DTOs;
using VShop.ProductApi.Extensions;
using VShop.ProductApi.Repositories.Category;

namespace VShop.ProductApi.Services.Category;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    public async Task<bool> Add(CategoryDto categoryDto)
    {
        var isSuccess = await categoryRepository.Add(categoryDto.ToCategory());

        return isSuccess;
    }

    public async Task<CategoryDto> Update(CategoryDto categoryDto)
    {
        var category = await categoryRepository.Update(categoryDto.ToCategory());

        return category.ToCategoryDto();
    }

    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        var categories = await categoryRepository.GetAll();

        return categories.Select(s => s.ToCategoryDto()).AsEnumerable();
    }

    public async Task<CategoryDto?> GetById(int id)
    {
        var category = await categoryRepository.GetById(id);

        return category?.ToCategoryDto();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesProducts()
    {
        var categories = await categoryRepository.GetCategoriesProducts();

        return categories.Select(s => s.ToCategoryDto());
    }

    public async Task<bool> Delete(int id)
    {
        var isSuccess = await categoryRepository.Delete(id);

        return isSuccess;
    }
}
