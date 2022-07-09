using Dvog.Domain;
using System.ComponentModel.DataAnnotations;

namespace Dvog.API.Contracts
{
    public class CreateAuthorRequest
    {
        [Required]
        [StringLength(Author.MaxUserName)]
        public string UserName { get; set; }

        public CreateAuthorRequest(string userName)
        {
            UserName = userName;
        }
    }
}
