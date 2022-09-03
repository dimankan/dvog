using CSharpFunctionalExtensions;

namespace Dvog.Domain
{
    public record Author
    {
        public const int MaxUserName = 20;
        private Author(int id, string userName, DateTime createdDate)
        {
            Id = id;
            UserName = userName;
            CreatedDate = createdDate;
        }

        public int Id { get; init; }

        public string UserName { get; }

        public DateTime CreatedDate { get; init; }

        public DateTime LastUpdateDate { get; init; }

        public static Result<Author> Create(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                return Result.Failure<Author>("Логин не может быть пустым");
            }

            var author = new Author(0, userName, DateTime.UtcNow);
            return author;
        }
    }
}
