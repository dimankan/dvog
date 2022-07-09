using CSharpFunctionalExtensions;

namespace Dvog.Domain
{
    public record Author
    {
        public const int MaxUserName = 20;
        private Author(int id, string userName, DateTime dateRegistr)
        {
            Id = id;
            UserName = userName;
            DateRegistr = dateRegistr;
        }

        public int Id { get; init; }

        public string UserName { get; }

        public DateTime DateRegistr { get; init; }

        public DateTime DateLastUpdate { get; init; }

        public static Result<Author> Create(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return Result.Failure<Author>("Логин не может быть пустым");
            }

            var author = new Author(0, userName, DateTime.Now);
            return author;
        }
    }
}
