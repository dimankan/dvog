using CSharpFunctionalExtensions;

namespace Dvog.DataAccess.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime DateRegistr { get; set; }

        public DateTime DateLastUpdate { get; set; }
    }
}
