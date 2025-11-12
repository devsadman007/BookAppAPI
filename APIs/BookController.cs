using AutoMapper;
using BookAppAPI.CommandQueries;
using BookAppAPI.Data;
using BookAppAPI.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookAppAPI.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BookController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookQuery>>> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<BookQuery>>(books));
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<BookQuery>> GetById(long id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<BookQuery>(book));
        }

     
        [HttpPost]
        public async Task<ActionResult<BookQuery>> Create([FromBody] BookCommand command)
        {
            var book = _mapper.Map<Book>(command);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok(book.Id);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] BookCommand command)
        {
            var existing = await _context.Books.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _mapper.Map(command, existing);
            await _context.SaveChangesAsync();

            return NoContent();
        }

     
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existing = await _context.Books.FindAsync(id);
            if (existing == null)
            {
                return NotFound();
            }

            _context.Books.Remove(existing);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
