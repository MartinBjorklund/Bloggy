using System;
using System.Collections.Generic;
using System.Text;


namespace Bloggy
{
    class comments
    {
        public int id { get; set; }
        public string Author { get; set; }
        public DateTime date { get; set; }
        public Blogpost post { get; set; }
    }
}