using VShop.ProductApi.DTOs;
using VShop.ProductApi.Extensions;
using VShop.ProductApi.Repositories.Product;

namespace VShop.ProductApi.Services.Product;

public class ProductService(IProductRepository productRepository) : IProductService
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<bool> Add(ProductDto productDto)
    {
        var isSucess = await _productRepository.Add(productDto.ToProduct());

        return isSucess;
    }

    public async Task<ProductDto> Update(ProductDto productDto)
    {
        var product = await _productRepository.Update(productDto.ToProduct());

        return product.ToProductDto();
    }

    public async Task<IEnumerable<ProductDto>> GetAll()
    {
        var products = await _productRepository.GetAll();

        return products.Select(s => s.ToProductDto()).AsEnumerable();
    }

    public async Task<ProductDto?> GetById(int id)
    {
        var product = await _productRepository.GetById(id);
        return product?.ToProductDto();
    }

    public async Task<bool> Delete(int id)
    {
        var isSucess = await _productRepository.Delete(id);

        return isSucess;
    }
}
