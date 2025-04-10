using VShop.ProductApi.DTOs;
using VShop.ProductApi.Extensions;
using VShop.ProductApi.Repositories.Category;

namespace VShop.ProductApi.Services.Category;

public class CategoryService(ICategoryRepository categoryRepository) : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;

    public async Task<bool> Add(CategoryDto categoryDto)
    {
        var isSucess = await _categoryRepository.Add(categoryDto.ToCategory());

        return isSucess;
    }

    public async Task<CategoryDto> Update(CategoryDto categoryDto)
    {
        var category = await _categoryRepository.Update(categoryDto.ToCategory());

        return category.ToCategoryDto();
    }

    public async Task<IEnumerable<CategoryDto>> GetAll()
    {
        var categories = await _categoryRepository.GetAll();

        return categories.Select(s => s.ToCategoryDto()).AsEnumerable();
    }

    public async Task<CategoryDto?> GetById(int id)
    {
        var category = await _categoryRepository.GetById(id);

        return category?.ToCategoryDto();
    }

    public async Task<IEnumerable<CategoryDto>> GetCategoriesProducts()
    {
        var categories = await _categoryRepository.GetCategoriesProducts();

        return categories.Select(s => s.ToCategoryDto()).AsEnumerable();
    }

    public async Task<bool> Delete(int id)
    {
        var isSucess = await _categoryRepository.Delete(id);

        return isSucess;
    }
}
