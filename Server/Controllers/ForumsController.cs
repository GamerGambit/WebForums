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
    public class ForumsController : ControllerBase
    {
        private readonly WebForumsContext _context;

        private IQueryable<ForumVM> FetchForumsAsViewModels()
		{
            return _context.Forum.Select(f => new ForumVM
            {
                ID = f.ID,
                Title = f.Title,
                Description = f.Description,
                Threads = f.Threads.Select(t => new ThreadShortVM
				{
                    ID = t.ID,
                    Title = t.Title,
                    Starter = new UserVM
                    {
                        ID = t.Starter.ID,
                        Username = t.Starter.Username
                    },
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
				})
            });
		}

        public ForumsController(WebForumsContext context)
        {
            _context = context;
        }

        /*
        // GET: api/Forums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForumVM>>> GetForum()
        {
            return await FetchForumsAsViewModels().ToListAsync();
        }
        */

        // GET: api/Forums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ForumVM>> GetForum(int id)
        {
            var forum = await FetchForumsAsViewModels().FirstOrDefaultAsync(f => f.ID == id);

            if (forum == null)
            {
                return NotFound();
            }

            return forum;
        }

        /*
        // PUT: api/Forums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutForum(int id, Forum forum)
        {
            if (id != forum.ID)
            {
                return BadRequest();
            }

            _context.Entry(forum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ForumExists(id))
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

        // POST: api/Forums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Forum>> PostForum(Forum forum)
        {
            _context.Forum.Add(forum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetForum", new { id = forum.ID }, forum);
        }

        // DELETE: api/Forums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteForum(int id)
        {
            var forum = await _context.Forum.FindAsync(id);
            if (forum == null)
            {
                return NotFound();
            }

            _context.Forum.Remove(forum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ForumExists(int id)
        {
            return _context.Forum.Any(e => e.ID == id);
        }
        */
    }
}
