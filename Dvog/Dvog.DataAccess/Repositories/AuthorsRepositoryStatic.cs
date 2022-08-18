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
                result += $"\nId: {item.Value.Id}\nUserName: {item.Value.UserName}.\nДата регистрации: {item.Value.DateRegistr}\n---Конец информации о пользователе---\n\n";
            }

            return result;
        }

        public string Get(int idAccount)
        {
            string result = string.Empty;

            if (!_authors.TryGetValue(idAccount, out var author))
            {
                return $"Автора с идентификатором {idAccount} не существует";
            }

            result += $"\nId: {author.Id}\nUserName: {author.UserName}.\nДата регистрации: {author.DateRegistr}\n---Конец информации о пользователе---\n\n";
            return result;
        }

        public string Update(int idAccount, Result<Author> updateAuthor)
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

        public string Delete(int idAccount)
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
