using System;
using System.Collections.Generic;
using System.Text;

namespace Bloggy
{
    public class Blogpost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Updated { get; set; }
        public List<Blogpost> Blogposts { get; set; }
        public Blogpost()
        {
            Blogposts = new List<Blogpost>();
        }
    }
}
