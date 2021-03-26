using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Models
{
    public class PhotoPost
    {
        // the name of the image file
        [StringLength(128), Required]
        public String Filename { get; set; }

        // a one line image caption
        [StringLength(30), Required]
        public String Caption { get; set; }

    }
}
