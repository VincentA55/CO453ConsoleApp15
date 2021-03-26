using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Models
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

    }
}
