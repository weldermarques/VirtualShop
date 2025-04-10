using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Product;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
    {
        try
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error fetching products");
        }
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        try
        {
            var products = await _productService.GetById(id);

            if (products is null)
                return NotFound("Product not found");

            return Ok(products);
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error fetching product");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDto productDto)
    {
        try
        {
            var isSuccess = await _productService.Add(productDto);

            if (!isSuccess)
                return NotFound("Product not found");

            return isSuccess ?
                Created() :
                BadRequest("Error add product");
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error add product");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] ProductDto productDto)
    {
        try
        {
            if (id != productDto.Id)
                return BadRequest();

            if (productDto is null)
                return BadRequest();

            var result = await _productService.Update(productDto);

            return Ok(result);
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error update product");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var products = await _productService.GetById(id);

            if (products is null)
                return NotFound("Product not found");

            var isSuccess = await _productService.Delete(id);

            return isSuccess ?
                Ok() :
                BadRequest("Error delete product");
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error delete product");
        }
    }
}
