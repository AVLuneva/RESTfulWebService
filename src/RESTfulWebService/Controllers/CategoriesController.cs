using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTfulWebService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RESTfulWebService.Controllers
{
    public class CategoriesController : ApiControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IAsyncEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory(long id)
        {
            Category category = await _context.Categories.Include(c => c.Products).FirstAsync(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            foreach (Product product in category.Products)
            {
                product.Category = null;
            };

            return Ok(category);
        }

        [HttpPatch("{id}")]
        public async Task<Category> PatchCategory(long id, JsonPatchDocument<Category> patchDoc)
        {
            Category Category = await _context.Categories.FindAsync(id);
            if (Category != null)
            {
                patchDoc.ApplyTo(Category);
                await _context.SaveChangesAsync();
            }
            return Category;
        }
    }
}
