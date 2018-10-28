using System;
using System.Collections.Generic;
using System.Text;

namespace ThisLookInfected
{
    public class Comment
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string CommentText { get; set; }
        public List<Comment> Responses { get; set; }
    }
}
