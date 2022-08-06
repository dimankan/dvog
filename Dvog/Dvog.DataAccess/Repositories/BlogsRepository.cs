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
        private Dictionary<int, Blog> _blogs = new Dictionary<int, Blog>();
        private int _latestId = 0;

        public BlogsRepository(DvogDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Add(Blog newBlog)
        {
            var blog = new Entities.Blog() { Text = newBlog.Text, Title = newBlog.Title};
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();

            return blog.Id;
        }

        public Blog[] GetAll()
        {
            var blogs = _dbContext.Blogs.AsNoTracking().ToArray();
            return _mapper.Map<Entities.Blog[], Blog[]>(blogs);
        }

        public string Get(int idBlog)
        {
            string result = string.Empty;

            if (!_blogs.TryGetValue(idBlog, out var blog))
            {
                return $"Блога с идентификатором {idBlog} не существует";
            }

            result += $"\nId: {blog.Id}\nЗаголовок: {blog.Title}.\nТекст: {blog.Text}\n---Конец блога---\n\n";

            return result;
        }

        public string Update(int idBlog, Result<Blog> updatedBlog)
        {
            string result = string.Empty;

            //var blog = _blogs[idBlog];
            if (!_blogs.TryGetValue(idBlog, out var blog))
            {
                return $"Блога с идентификатором {idBlog} не существует";
            }

            //var newBlog = Blog.Create(blog.Title + " " + DateTime.Now, blog.Text + " " + DateTime.Now);
            //newBlog = newBlog.Value with { Id = idBlog };
            //_blogs[idBlog] = newBlog.Value;

            // Тут снова Value!!!
            _blogs[idBlog] = updatedBlog.Value with { Id = blog.Id };

            result = $"Блог с идентификатором {idBlog} обновлен";

            return result;
        }

        public string Delete(int idBlog)
        {
            string result = string.Empty;

            if (!_blogs.ContainsKey(idBlog))
            {
                return $"Блога c идентификатором {idBlog} не существует";
            }

            _blogs.Remove(idBlog);
            result = $"Блог с идентификатором {idBlog} удалён";

            return result;
        }
    }
}
