using System.ComponentModel.DataAnnotations;

namespace CS_BLOG.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [MinLength(1)]
        public string Body { get; set; }

        [Required]
        public string Author{ get; set; }
        [Required]
        public int BlogId { get; set; }
    }
}