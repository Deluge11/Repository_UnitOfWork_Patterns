using Microsoft.AspNetCore.Mvc;
using Repository_UOW.Core.Interfaces;
using Repository_UOW.Core.Models;

namespace Repository_UOW.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private IUnitOfWork UnitOfWork { get; }


        public AuthorsController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(UnitOfWork.Authors.GetById(id));
        }

        [HttpGet("GetAsync/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await UnitOfWork.Authors.GetByIdAsync(id));
        }
    }
}
