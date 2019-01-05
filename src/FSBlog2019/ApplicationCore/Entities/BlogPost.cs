using System;
using System.Collections.Generic;
using System.Text;

namespace StraussDA.ApplicationCore.Entities
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string Post { get; set; }

    }
}
