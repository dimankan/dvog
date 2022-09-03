using Dvog.Domain;
using System.ComponentModel.DataAnnotations;

namespace Dvog.API.Contracts
{
    /// <summary>
    /// Реквест модель 
    /// </summary>
    public class CreateBlogRequest
    {
        public CreateBlogRequest(string title, string text)
        {
            Title = title;
            Text = text;
        }

        /// <summary>
        /// Название блога
        /// </summary>
        [Required] // 
        [StringLength(Blog.MaxTitleLength)]
        public string Title { get; set; } = string.Empty;
        
        /// <summary>
        /// Текст блога
        /// </summary>
        [Required]
        [StringLength(Blog.MaxTextLength)]
        public string Text { get; set; } = null!;
    }
}