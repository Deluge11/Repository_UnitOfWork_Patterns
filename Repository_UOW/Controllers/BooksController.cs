using Microsoft.AspNetCore.Mvc;
using Repository_UOW.Core.Interfaces;
using Repository_UOW.Core.Models;
using System.Threading.Tasks;

namespace Repository_UOW.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public IBaseRepository<Book> BookRepository { get; }


        public BooksController(IBaseRepository<Book> bookRepository)
        {
            BookRepository = bookRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(BookRepository.GetById(id));
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await BookRepository.GetByIdAsync(id));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await BookRepository.GetAll());
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return Ok(await BookRepository.Find(b=>b.Title == name.Trim()));
        }
    }
}
