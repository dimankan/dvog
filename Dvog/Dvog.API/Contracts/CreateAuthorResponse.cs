using Dvog.Domain;
using System.ComponentModel.DataAnnotations;

namespace Dvog.API.Contracts
{
    public class CreateAuthorResponse
    {
        [Required]
        public string? ErrorMessage { get; set; }

        [Required]
        public int IdAuthor { get; set; }
    }
}
