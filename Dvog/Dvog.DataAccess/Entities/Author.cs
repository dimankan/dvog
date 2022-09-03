using CSharpFunctionalExtensions;

namespace Dvog.DataAccess.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
