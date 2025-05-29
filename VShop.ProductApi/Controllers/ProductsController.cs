using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Product;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService,
    ILogger<ProductsController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
    {
        try
        {
            var products = await productService.GetAll();
            return Ok(products);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error fetching products");
        }
    }

    [HttpGet("{id:int}", Name = "GetProduct")]
    public async Task<ActionResult<ProductDto>> Get(int id)
    {
        try
        {
            var products = await productService.GetById(id);

            if (products is null)
                return NotFound("Product not found");

            return Ok(products);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error fetching product");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] ProductDto productDto)
    {
        try
        {
            var isSuccess = await productService.Add(productDto);

            if (!isSuccess)
                return NotFound("Product not found");

            return isSuccess ?
                Created() :
                BadRequest("Error add product");
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
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

            var result = await productService.Update(productDto);

            return Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error update product");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var products = await productService.GetById(id);

            if (products is null)
                return NotFound("Product not found");

            var isSuccess = await productService.Delete(id);

            return isSuccess ?
                Ok() :
                BadRequest("Error delete product");
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error delete product");
        }
    }
}
