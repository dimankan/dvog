using CSharpFunctionalExtensions;

namespace Dvog.Domain
{
    public class Author
    {
        private Author(int id, string login, string password, string email, string phone, string firstName, string secondName, DateTime birthday, DateTime dateRegistr)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
            Phone = phone;
            FirstName = firstName;
            SecondName = secondName;
            Birthday = birthday;
            DateRegistr = dateRegistr;
        }

        public int Id { get; set; }

        public string Login { get; }

        public string Password { get; }

        public string Email { get; }

        public string Phone { get; }

        public string FirstName { get; }

        public string SecondName { get; }

        public DateTime Birthday { get; }

        public DateTime DateRegistr { get; }

        public static Result<Author> Create(string login, string password, string email, string phone, string firstName, string secondName, DateTime birthday)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return Result.Failure<Author>("Логин не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return Result.Failure<Author>("Пароль не может быть пустым");
            }

            var blog = new Author(0, login, password, email, phone, firstName, secondName, birthday, DateTime.Now);
            return blog;
        }
    }
}
