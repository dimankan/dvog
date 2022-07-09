using Dvog.Domain;
using System.ComponentModel.DataAnnotations;

namespace Dvog.API.Contracts
{
    public class UpdateAuthorRequest
    {
        public UpdateAuthorRequest(string userName)
        {
            UserName = userName;
        }

        [Required]
        [StringLength(Author.MaxUserName)]
        public string UserName { get; set; } = string.Empty;
    }
}