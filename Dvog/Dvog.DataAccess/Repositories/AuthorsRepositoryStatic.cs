using CSharpFunctionalExtensions;
//using Dvog.API.Contracts;
using Dvog.Domain;
using Dvog.Domain.Repositories;

namespace Dvog.DataAccess.Repositories
{
    public class AuthorsRepositoryStatic //: IAuthorsRepository
    {
        private int _latestId = 0;
        private Dictionary<int, Author> _authors = new Dictionary<int, Author>();

        public int Add(Author newAuthor)
        {
            _latestId++;

            var author = newAuthor with { Id = _latestId };

            _authors.Add(author.Id, author);

            return author.Id;
        }

        public string GetAll()
        {
            string result = string.Empty;

            foreach (var item in _authors)
            {
                result += $"\nId: {item.Value.Id}\nUserName: {item.Value.UserName}.\nДата регистрации: {item.Value.CreatedDate}\n---Конец информации о пользователе---\n\n";
            }

            return result;
        }

        public string Get(int accountId)
        {
            string result = string.Empty;

            if (!_authors.TryGetValue(accountId, out var author))
            {
                return $"Автора с идентификатором {accountId} не существует";
            }

            result += $"\nId: {author.Id}\nUserName: {author.UserName}.\nДата регистрации: {author.CreatedDate}\n---Конец информации о пользователе---\n\n";
            return result;
        }

        public string Update(int accountId, Result<Author> updateAuthor)
        {
            string result = string.Empty;

            if (!_authors.TryGetValue(accountId, out var author))
            {
                return $"Автора с идентификатором {accountId} не существует";
            }

            _authors[accountId] = updateAuthor.Value with { Id = author.Id, CreatedDate = author.CreatedDate, LastUpdateDate = DateTime.UtcNow };

            result = $"Автор с идентификатором {accountId} обновлен";

            return result;
        }

        public string Delete(int accountId)
        {
            string result = string.Empty;

            if (!_authors.ContainsKey(accountId))
            {
                return $"Автора с идентификатором {accountId} не существует";
            }

            _authors.Remove(accountId);
            result = $"Автор с идентификатором {accountId} удалён";

            return result;
        }
    }
}
