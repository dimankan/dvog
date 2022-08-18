using Dvog.API.Contracts;
using Dvog.DataAccess.Repositories;
using Dvog.Domain;
using Dvog.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dvog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IAuthorsRepository _authorsRepository;

        public AuthorController(ILogger<AuthorController> logger, IAuthorsRepository repository)
        {
            _logger = logger;
            _authorsRepository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorRequest request)
        {
            _logger.LogInformation("Начало создания автора");
            var author = Author.Create(request.UserName);
            if (author.IsFailure)
            {
                _logger.LogError(author.Error);
                return BadRequest(author.Error);
            }

            var response = _authorsRepository.Add(author.Value);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Начало получения всех блогов");

            var result = _authorsRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> Get([FromRoute] int authorId)
        {
            _logger.LogInformation($"Начало получения конкретного автора с идентификатором: {authorId}");

            var result = _authorsRepository.Get(authorId);

            return Ok(result);
        }

        [HttpPut("{authorId:int}")]
        public async Task<IActionResult> Update([FromRoute] int authorId, UpdateAuthorRequest request)
        {
            _logger.LogInformation($"Начало обновления конкретного автора с идентификатором: {authorId}");

            var updatedAuthor = Author.Create(request.UserName);
            var result = _authorsRepository.Update(authorId, updatedAuthor);

            return Ok(result);
        }

        [HttpDelete("{authorId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int authorId)
        {
            _logger.LogInformation($"Начало удаления конкретного автора с идентификатором: {authorId}");

            var result = _authorsRepository.Delete(authorId);

            return Ok(result);
        }
    }
}
