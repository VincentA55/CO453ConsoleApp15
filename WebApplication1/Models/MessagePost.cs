using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApps.Models
{
    public class MessagePost
    {

        // an arbitrarily long, multi-line message
        [StringLength(256), DataType(DataType.MultilineText)]
        public String Message { get; set; }

    }
}
