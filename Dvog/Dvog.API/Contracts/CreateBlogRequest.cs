using Dvog.Domain;
using System.ComponentModel.DataAnnotations;

namespace Dvog.API.Contracts
{
    public class CreateBlogRequest
    {
        [Required]
        [StringLength(Blog.MaxTitleLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(Blog.MaxTextLength)]
        public string Text { get; set; }
    }
}