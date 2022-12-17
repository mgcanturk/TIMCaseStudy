using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIMCaseStudy.Application.Repositories;

namespace TIMCaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookReadRepository _bookReadRepository;
        private readonly IBookWriteRepository _bookWriteRepository;
        public BookController(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository)
        {
            _bookReadRepository = bookReadRepository;
            _bookWriteRepository = bookWriteRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _bookWriteRepository.AddAsync(new() {
                Name = "Test Kitap",
                ISBN = "12345678911",
                Publisher = "Pegasus Yayınları",
                IsAvailable = true,
                CategoryId = 4,
                AuthorId = 1,
                CreateDateTime = DateTime.Now,
                UpdateDateTime = DateTime.Now
            });
            int count = await _bookWriteRepository.SaveAsync();
            return Ok(count);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        { 
            var GetData = await _bookReadRepository.GetByIdAsync(id, false);
            return Ok(GetData);
        }
    }
}
