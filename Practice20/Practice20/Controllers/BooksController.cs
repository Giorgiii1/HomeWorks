using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practice20.Data;
using Practice20.Models;

namespace Practice20.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? title,
            [FromQuery] string? genre,
            [FromQuery] bool sortByYearDescending = false,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 10)
        {
            var query = _context.Books.AsQueryable();
            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            if (!string.IsNullOrWhiteSpace(genre))
            {
                query = query.Where(b => b.Genre.ToLower() == genre.ToLower());
            }

            query = sortByYearDescending
                ? query.OrderByDescending(b => b.PublishYear)
                : query.OrderBy(b => b.PublishYear);

            var books = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return Ok(books);
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound(new { Message = $"წიგნი ID-ით {id} ვერ მოიძებნა." });
            }

            return Ok(book);
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
        
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Book updatedBook)
        {
            if (id != updatedBook.Id)
            {
                return BadRequest(new { Message = "URL-ის ID და წიგნის ID ერთმანეთს არ ემთხვევა." });
            }

            var existingBook = await _context.Books.FindAsync(id);
            if (existingBook == null)
            {
                return NotFound(new { Message = $"წიგნი ID-ით {id} ვერ მოიძებნა." });
            }

            
            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.PublishYear = updatedBook.PublishYear;
            existingBook.Genre = updatedBook.Genre;
            existingBook.IsAvailable = updatedBook.IsAvailable;

            await _context.SaveChangesAsync();

            return NoContent(); 
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound(new { Message = $"წიგნი ID-ით {id} ვერ მოიძებნა." });
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(new { Message = $"წიგნი ID-ით {id} წარმატებით წაიშალა." });
        }
    }
    
}
        