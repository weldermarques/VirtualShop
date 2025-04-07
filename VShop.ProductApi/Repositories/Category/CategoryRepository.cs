using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;
using CategoryEntity = VShop.ProductApi.Models.Category;

namespace VShop.ProductApi.Repositories.Category
{
    public class CategoryRepository(AppDbContext context) : ICategoryRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<bool> Add(CategoryEntity category)
        {
            _context.Categories.Add(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            return await _context.Categories.Where(c => c.Id == id)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<IEnumerable<CategoryEntity>> GetAll()
        {
            var categories = await _context.Categories
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryEntity?> GetById(int id)
        {
            var category = await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<IEnumerable<CategoryEntity>> GetCategoriesProducts()
        {
            var categories = await _context.Categories
                .Include(p => p.Products)
                .ToListAsync();

            return categories;
        }

        public async Task<CategoryEntity> Update(CategoryEntity category)
        {
            _context.Entry(category).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return category;

        }
    }
}
