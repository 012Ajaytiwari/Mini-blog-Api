// using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniBlogAPI.Data;
using MiniBlogAPI.Models;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MiniBlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BlogController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Blog?pageNumber=1&pageSize=5
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var totalPosts = await _context.BlogPosts.CountAsync();
            var posts = await _context.BlogPosts
                .Include(p => p.Author)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.CreatedAt,
                    Author = p.Author.UserName
                })
                .ToListAsync();

            return Ok(new
            {
                TotalCount = totalPosts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalPosts / (double)pageSize),
                Items = posts
            });
        }

        // GET: api/Blog/{id}
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _context.BlogPosts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                return NotFound();

            return Ok(new
            {
                post.Id,
                post.Title,
                post.Content,
                post.CreatedAt,
                Author = post.Author.UserName
            });
        }

        // POST: api/Blog
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BlogPost model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            model.AuthorId = userId;
            model.CreatedAt = DateTime.UtcNow;

            _context.BlogPosts.Add(model);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Blog post created successfully." });
        }

        // PUT: api/Blog/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BlogPost model)
        {
            var existingPost = await _context.BlogPosts.FindAsync(id);
            if (existingPost == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (existingPost.AuthorId != userId)
                return Forbid();

            existingPost.Title = model.Title;
            existingPost.Content = model.Content;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Blog post updated successfully." });
        }

        // DELETE: api/Blog/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (post.AuthorId != userId)
                return Forbid();

            _context.BlogPosts.Remove(post);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Blog post deleted successfully." });
        }
    }
}
 for Blogs with pagination
