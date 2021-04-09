using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MessagePost : Post
    {

        // an arbitrarily long, multi-line message
        [StringLength(256), DataType(DataType.MultilineText)]
        public String Message { get; set; }

    }
}
