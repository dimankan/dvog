using CSharpFunctionalExtensions;
using Dvog.Domain;

namespace Dvog.Domain.Repositories
{
    public interface IAuthorsRepository
    {
        int Add(Author newAuthor);

        Result<string> Delete(int accountId);

        Result<Author> Get(int accountId);

        Result<Author[]> GetAll();

        Result<Author> Update(int accountId, Author updateAuthor);
    }
}