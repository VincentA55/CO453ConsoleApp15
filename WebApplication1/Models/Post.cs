using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public int likes { get; set; }

        public readonly List<String> comments;

        // username of the post's author
        [StringLength(30), Required]
        public String Username { get; set; }

        public DateTime Timestamp { get; set; }

        
        public Post()
        {
            Timestamp = DateTime.Now;
            likes = 0;
        }

        public void Like()
        {
            likes++;
        }

        public void Unlike()
        {
            if (likes > 0)
            {
                likes--;
            }
        }
    }
}
