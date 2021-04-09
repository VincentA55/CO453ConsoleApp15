using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class PhotoPost : Post
    {
        // the name of the image file
        [StringLength(128), Required]
        public String Filename { get; set; }

        // a one line image caption
        [StringLength(30), Required]
        public String Caption { get; set; }

    }
}
