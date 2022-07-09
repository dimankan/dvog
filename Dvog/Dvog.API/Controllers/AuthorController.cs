using CSharpFunctionalExtensions;
using Dvog.API.Contracts;
using Dvog.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Dvog.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(ILogger<AuthorController> logger)
        {
            _logger = logger;
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

            var response = AuthorsRepository.Add(author.Value);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Начало получения всех блогов");

            var result = AuthorsRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("{authorId:int}")]
        public async Task<IActionResult> Get([FromRoute] int authorId)
        {
            _logger.LogInformation($"Начало получения конкретного автора с идентификатором: {authorId}");

            var result = AuthorsRepository.Get(authorId);

            return Ok(result);
        }

        [HttpPut("{authorId:int}")]
        public async Task<IActionResult> Update([FromRoute] int authorId, UpdateAuthorRequest request)
        {
            _logger.LogInformation($"Начало обновления конкретного автора с идентификатором: {authorId}");

            var updatedAuthor = Author.Create(request.UserName);
            var result = AuthorsRepository.Update(authorId, updatedAuthor);

            return Ok(result);
        }

        [HttpDelete("{authorId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int authorId)
        {
            _logger.LogInformation($"Начало удаления конкретного автора с идентификатором: {authorId}");

            var result = AuthorsRepository.Delete(authorId);

            return Ok(result);
        }
    }

    public static class AuthorsRepository
    {
        private static int _latestId = 0;
        private static Dictionary<int, Author> _authors = new Dictionary<int, Author>();

        public static CreateAuthorResponse Add(Author newAuthor)
        {
            CreateAuthorResponse response = new CreateAuthorResponse();

            // Проверка на наличия такого же userName
            List<string> haveUserName = new List<string>();
            foreach (var item in _authors)
            {
                haveUserName.Add(item.Value.UserName);
            }

            if (haveUserName.Contains(newAuthor.UserName))
            {
                response.ErrorMessage = $"Автор с таким именим уже существует. Выберите другое.";
                return response;
            }

            _latestId++;
            var author = newAuthor with { Id = _latestId };
            _authors.Add(author.Id, author);
            response.IdAuthor = author.Id;
            return response;
        }

        public static string GetAll()
        {
            string result = string.Empty;

            foreach (var item in _authors)
            {
                result += $"\nId: {item.Value.Id}\nUserName: {item.Value.UserName}.\nДата регистрации: {item.Value.DateRegistr}\n---Конец информации о пользователе---\n\n";
            }

            return result;
        }

        public static string Get(int idAccount)
        {
            string result = string.Empty;

            if (!_authors.TryGetValue(idAccount, out var author))
            {
                return $"Автора с идентификатором {idAccount} не существует";
            }

            result += $"\nId: {author.Id}\nUserName: {author.UserName}.\nДата регистрации: {author.DateRegistr}\n---Конец информации о пользователе---\n\n";
            return result;
        }

        public static string Update(int idAccount, Result<Author> updateAuthor)
        {
            string result = string.Empty;

            if (!_authors.TryGetValue(idAccount, out var author))
            {
                return $"Автора с идентификатором {idAccount} не существует";
            }

            _authors[idAccount] = updateAuthor.Value with { Id = author.Id, DateRegistr = author.DateRegistr, DateLastUpdate = DateTime.Now };

            result = $"Автор с идентификатором {idAccount} обновлен";

            return result;
        }

        public static string Delete(int idAccount)
        {
            string result = string.Empty;

            if (!_authors.ContainsKey(idAccount))
            {
                return $"Автора с идентификатором {idAccount} не существует";
            }

            _authors.Remove(idAccount);
            result = $"Автор с идентификатором {idAccount} удалён";

            return result;
        }
    }
}
