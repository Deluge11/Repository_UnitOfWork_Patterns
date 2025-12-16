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
        private IUnitOfWork UnitOfWork { get; }

        public BooksController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(UnitOfWork.Books.GetById(id));
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await UnitOfWork.Books.GetByIdAsync(id));
        }

        [HttpGet("GetAllAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await UnitOfWork.Books.GetAll());
        }

        [HttpGet("GetByName/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            return Ok(await UnitOfWork.Books.Find(b => b.Title == name.Trim()));
        }

        [HttpGet("GetWithAuthor/{name}")]
        public IActionResult GetWithAuthor(string name)
        {
            return Ok(UnitOfWork.Books.Find(b => b.Title == name.Trim(), new string[] { "Author" }));
        }

        [HttpGet("GetSlice")]
        public IActionResult GetSlice()
        {
            return Ok(UnitOfWork.Books.Find(b => b.Title == "Test", new string[] { "Author" },0,1));
        }

        [HttpGet("Special")]
        public IActionResult Special()
        {
            UnitOfWork.Books.BookOnlyFunction();
            return Ok();
        }

        [HttpPost("FakeAdd")]
        public IActionResult Add()
        {
            //Add to DB

            UnitOfWork.Complete();

            return Ok();
        }
    }
}
