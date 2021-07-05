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
    public class ThreadsController : ControllerBase
    {
        private readonly WebForumsContext _context;

        public ThreadsController(WebForumsContext context)
        {
            _context = context;
        }

        // GET: api/Threads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thread>>> GetThread()
        {
            return await _context.Thread.ToListAsync();
        }

        // GET: api/Threads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThreadVM>> GetThread(int id)
        {
            var thread = await _context.Thread.Select(t => new ThreadVM
            {
                ID = t.ID,
                Title = t.Title,
                Posts = t.Posts.Select(p => new PostVM
                {
                    ID = p.ID,
                    Created = p.Created,
                    Content = p.Content,
                    Update = p.Update,
                    Poster = new UserVM
                    {
                        ID = p.Poster.ID,
                        Username = p.Poster.Username
                    }
                })
            }).FirstOrDefaultAsync(t => t.ID == id);

            if (thread == null)
            {
                return NotFound();
            }

            return thread;
        }

        // PUT: api/Threads/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThread(int id, Thread thread)
        {
            if (id != thread.ID)
            {
                return BadRequest();
            }

            _context.Entry(thread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadExists(id))
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

        // POST: api/Threads
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Thread>> PostThread(Thread thread)
        {
            _context.Thread.Add(thread);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThread", new { id = thread.ID }, thread);
        }

        // DELETE: api/Threads/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThread(int id)
        {
            var thread = await _context.Thread.FindAsync(id);
            if (thread == null)
            {
                return NotFound();
            }

            _context.Thread.Remove(thread);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThreadExists(int id)
        {
            return _context.Thread.Any(e => e.ID == id);
        }
    }
}
