using System.ComponentModel.DataAnnotations;

namespace CS_BLOG.Models
{
    public class Blog
    {
        public int Id {get; set;}
        [Required]
        public string Title {get; set;}
        [MinLength(10)]
        public string Body{get; set;}
        [Required]
        public string Author{get; set;}
    }
}