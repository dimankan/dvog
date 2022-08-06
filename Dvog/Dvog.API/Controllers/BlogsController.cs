using Dvog.API.Contracts;
using Dvog.DataAccess;
using Dvog.DataAccess.Repositories;
using Dvog.Domain;
using Dvog.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dvog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly ILogger<BlogsController> _logger;
        private readonly IBlogsRepository _blogRepository;

        public BlogsController(ILogger<BlogsController> logger, IBlogsRepository repository)
        {
            _logger = logger;
            _blogRepository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogRequest request)
        {
            _logger.LogInformation("Начало создания блога");
            var blog = Blog.Create(request.Title, request.Text);
            if (blog.IsFailure)
            {
                _logger.LogError(blog.Error);
                return BadRequest(blog.Error);
            }

            var blogId = _blogRepository.Add(blog.Value);
            return Ok(blogId);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Начало получения всех блогов");

            var result = _blogRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{blogId:int}")]
        public async Task<IActionResult> Get([FromRoute] int blogId)
        {
            _logger.LogInformation($"Начало получения конкретного блога с идентификатором: {blogId}");

            var result = _blogRepository.Get(blogId);

            return Ok(result);
        }

        [HttpPut("{blogId:int}")]
        public async Task<IActionResult> Update([FromRoute] int blogId, UpdateBlogRequest request)
        {
            _logger.LogInformation($"Начало обновления конкретного блога с идентификатором: {blogId}");

            var updatedBlog = Blog.Create(request.Title, request.Text);

            var result = _blogRepository.Update(blogId, updatedBlog);

            return Ok(result);
        }

        [HttpDelete("{blogId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int blogId)
        {
            _logger.LogInformation($"Начало удаления конкретного блога с идентификатором: {blogId}");

            var result = _blogRepository.Delete(blogId);

            return Ok(result);
        }
    }
}
