using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Category;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService, 
    ILogger<CategoriesController> logger) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
    {
        try
        {
            var categories = await categoryService.GetAll();
            return Ok(categories);
        }
        catch(Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error fetching categories");
        }
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesProducts()
    {
        try
        {
            var categories = await categoryService.GetCategoriesProducts();
            return Ok(categories);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error fetching categories");
        }
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
        try
        {
            var category = await categoryService.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            return Ok(category);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error fetching category");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDto categoryDto)
    {
        try
        {
            var isSuccess = await categoryService.Add(categoryDto);

            if (!isSuccess)
                return NotFound("Category not found");

            return isSuccess?  
                Created() :
                BadRequest("Error add category");
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error add category");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] CategoryDto categoryDto)
    {
        try
        {
            if (id != categoryDto.Id)
                return BadRequest();

            var result = await categoryService.Update(categoryDto);

            return Ok(result);
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error update category");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var category = await categoryService.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            var isSuccess = await categoryService.Delete(id);

            return isSuccess ?
                Ok() :
                BadRequest("Error delete category");
        }
        catch (Exception e)
        {
            logger.LogError(e.Message, e.InnerException);
            return BadRequest("Error delete category");
        }
    }
}
