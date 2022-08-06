using CSharpFunctionalExtensions;

namespace Dvog.Domain.Repositories
{
    public interface IBlogsRepository
    {
        int Add(Blog newBlog);

        string Delete(int idBlog);

        string Get(int idBlog);

        Blog[] GetAll();

        string Update(int idBlog, Result<Blog> updatedBlog);
    }
}