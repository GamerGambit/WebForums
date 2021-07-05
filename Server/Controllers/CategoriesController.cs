using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebForums.Server.Data;
using WebForums.Server.Models;
using WebForums.Shared;

namespace WebForums.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly WebForumsContext _context;

        private IQueryable<CategoryVM> FetchCategoriesAsViewModels()
		{
            return _context.Category.Select(c => new CategoryVM
            {
                ID = c.ID,
                Title = c.Title,
                ForumShorts = c.Forums.Select(f => new ForumShortVM
                {
                    ID = f.ID,
                    Title = f.Title,
                    Description = f.Description,
                    LatestThreadPostedIn = f.Threads.OrderBy(t => t.Posts.OrderBy(p => p.Created).Last()).Select(t => new ThreadShortVM
                    {
                        ID = t.ID,
                        Title = t.Title,
                        LastestPost = t.Posts.OrderBy(p => p.Created).Select(p => new PostShortVM
                        {
                            ID = p.ID,
                            Poster = new UserVM
                            {
                                ID = p.Poster.ID,
                                Username = p.Poster.Username
                            },
                            Created = p.Created
                        }).Last()
                    }).LastOrDefault()
                })
            });
        }

        public CategoriesController(WebForumsContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVM>>> GetCategory()
        {
            // System.Text.Json cannot serialize `Category.Forums` without dying from cyclic references from `Forum.Category`, so null the reference.
            return await FetchCategoriesAsViewModels().ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVM>> GetCategory(int id)
        {
            // System.Text.Json cannot serialize `Category.Forums` without dying from cyclic references from `Forum.Category`, so null the reference.
            var category = await FetchCategoriesAsViewModels().FirstOrDefaultAsync(c => c.ID == id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        /*
        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.ID)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.ID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(int id)
        {
            return _context.Category.Any(e => e.ID == id);
        }
        */
    }
}
