using CSharpFunctionalExtensions;

namespace Dvog.Domain;
public record Blog
{
    public const int MaxTitleLength = 200;

    public const int MaxTextLength = 2000;
    private Blog(int id, string title, string text)
    {
        Id = id;
        Title = title;
        Text = text;
    }

    public int Id { get; init; }

    public string Title { get; }

    public string Text { get; }

    public static Result<Blog> Create(string title, string text)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return Result.Failure<Blog>("Заголовок не может быть пустым");
        }

        if (string.IsNullOrWhiteSpace(text))
        {
            return Result.Failure<Blog>("Текст не может быть пустым");
        }

        var blog = new Blog(0, title, text);
        return blog;
    }
}
