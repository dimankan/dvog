using Dvog.Domain;
using System.ComponentModel.DataAnnotations;

namespace Dvog.API.Contracts
{
    public class CreateBlogRequest
    {
        public CreateBlogRequest(string title, string text)
        {
            Title = title;
            Text = text;
        }

        [Required]
        [StringLength(Blog.MaxTitleLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(Blog.MaxTextLength)]
        public string Text { get; set; } = null!;
    }
}