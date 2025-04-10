using Microsoft.EntityFrameworkCore;
using VShop.ProductApi.Context;

using ProductyEntity = VShop.ProductApi.Models.Product;

namespace VShop.ProductApi.Repositories.Product;

public class ProductyRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    public async Task<bool> Add(ProductyEntity product)
    {
        _context.Products.Add(product);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(int id)
    {
        return await _context.Products.Where(c => c.Id == id)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<IEnumerable<ProductyEntity>> GetAll()
    {
        var products = await _context.Products
            .ToListAsync();

        return products;
    }

    public async Task<ProductyEntity?> GetById(int id)
    {
        var product = await _context.Products
            .FirstOrDefaultAsync(c => c.Id == id);

        return product;
    }


    public async Task<ProductyEntity> Update(ProductyEntity product)
    {
        _context.Entry(product).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return product;
    }
}
