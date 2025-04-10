using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services.Category;

namespace VShop.ProductApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    private readonly ICategoryService _categoryService = categoryService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> Get()
    {
        try
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }
        catch(Exception e)
        {
            //Create log
            return BadRequest("Error fetching categories");
        }
    }

    [HttpGet("products")]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesProducts()
    {
        try
        {
            var categories = await _categoryService.GetCategoriesProducts();
            return Ok(categories);
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error fetching categories");
        }
    }

    [HttpGet("{id:int}", Name = "GetCategory")]
    public async Task<ActionResult<CategoryDto>> Get(int id)
    {
        try
        {
            var category = await _categoryService.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            return Ok(category);
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error fetching category");
        }
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CategoryDto categoryDto)
    {
        try
        {
            var isSuccess = await _categoryService.Add(categoryDto);

            if (!isSuccess)
                return NotFound("Category not found");

            return isSuccess?  
                Created() :
                BadRequest("Error add category");
        }
        catch (Exception e)
        {
            //Create log
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

            if (categoryDto is null)
                return BadRequest();

            var result = await _categoryService.Update(categoryDto);

            return Ok(result);
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error update category");
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var category = await _categoryService.GetById(id);

            if (category is null)
                return NotFound("Category not found");

            var isSuccess = await _categoryService.Delete(id);

            return isSuccess ?
                Ok() :
                BadRequest("Error delete category");
        }
        catch (Exception e)
        {
            //Create log
            return BadRequest("Error delete category");
        }
    }
}
