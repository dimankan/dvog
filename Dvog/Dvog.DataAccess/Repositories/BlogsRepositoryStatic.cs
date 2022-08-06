using CSharpFunctionalExtensions;
using Dvog.Domain;

namespace Dvog.DataAccess.Repositories
{
    public static class BlogsRepositoryStatic
    {
        private static int _latestId = 0;
        private static Dictionary<int, Blog> _blogs = new Dictionary<int, Blog>();

        public static int Add(Blog newBlog)
        {
            _latestId++;

            var blog = newBlog with { Id = _latestId };

            _blogs.Add(blog.Id, blog);

            return blog.Id;
        }

        public static string GetAll()
        {
            string result = string.Empty;

            foreach (var item in _blogs)
            {
                result += $"\nId: {item.Value.Id}\nЗаголовок: {item.Value.Title}.\nТекст: {item.Value.Text}\n---Конец блога---\n\n";
            }

            return result;
        }

        public static string Get(int idBlog)
        {
            string result = string.Empty;

            if (!_blogs.TryGetValue(idBlog, out var blog))
            {
                return $"Блога с идентификатором {idBlog} не существует";
            }

            result += $"\nId: {blog.Id}\nЗаголовок: {blog.Title}.\nТекст: {blog.Text}\n---Конец блога---\n\n";

            return result;
        }

        public static string Update(int idBlog, Result<Blog> updatedBlog)
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

        public static string Delete(int idBlog)
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
