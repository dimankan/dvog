using CSharpFunctionalExtensions;
using Dvog.Domain;

namespace Dvog.Domain.Repositories
{
    public interface IAuthorsRepository
    {
        int Add(Author newAuthor);

        string Delete(int idAccount);

        Author Get(int idAccount);

        Author[] GetAll();

        Author Update(int idAccount, Result<Author> updateAuthor);
    }
}