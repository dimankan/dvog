using AutoMapper;
using CSharpFunctionalExtensions;
using Dvog.Domain;
using Dvog.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Dvog.DataAccess.Repositories
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly DvogDbContext _dbContext;
        private readonly IMapper _mapper;

        public BlogsRepository(DvogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Add(Blog newBlog)
        {
            var blog = new Entities.Blog() { Text = newBlog.Text, Title = newBlog.Title };
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();

            return blog.Id;
        }

        public Blog[] GetAll()
        {
            var blogs = _dbContext.Blogs.AsNoTracking().ToArray();
            return _mapper.Map<Entities.Blog[], Blog[]>(blogs);
        }

        public Blog Get(int idBlog)
        {
            var blog = _dbContext.Blogs.SingleOrDefault(b => b.Id == idBlog);
            return _mapper.Map<Entities.Blog, Blog>(blog);
        }

        public Blog Update(int idBlog, Result<Blog> updatedBlog)
        {
            var blog = _dbContext.Blogs.SingleOrDefault(b => b.Id == idBlog);

            blog.Text = updatedBlog.Value.Text;
            blog.Title = updatedBlog.Value.Title;

            _dbContext.Update(blog);
            _dbContext.SaveChanges();

            return _mapper.Map<Entities.Blog, Blog>(blog);
        }

        public string Delete(int idBlog)
        {
            var blog = _dbContext.Blogs.SingleOrDefault(b => b.Id == idBlog);

            _dbContext.Remove(blog);
            _dbContext.SaveChanges();

            return $"Delete {blog.Title} with Id = {idBlog}";
        }
    }
}
