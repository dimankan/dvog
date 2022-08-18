using CSharpFunctionalExtensions;

namespace Dvog.Domain.Repositories
{
    public interface IBlogsRepository
    {
        int Add(Blog newBlog);

        string Delete(int idBlog);

        Blog Get(int idBlog);

        Blog[] GetAll();

        Blog Update(int idBlog, Result<Blog> updatedBlog);
    }
}