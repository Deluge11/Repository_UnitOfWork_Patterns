using Microsoft.AspNetCore.Mvc;
using Repository_UOW.Core.Interfaces;
using Repository_UOW.Core.Models;

namespace Repository_UOW.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public IBaseRepository<Author> AuthorRepository { get; }


        public AuthorsController(IBaseRepository<Author> authorRepository)
        {
            AuthorRepository = authorRepository;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(AuthorRepository.GetById(id));
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await AuthorRepository.GetByIdAsync(id));
        }
    }
}
