using System;
using System.Collections.Generic;
using System.Text;

namespace ThisLookInfected
{
    public class Post
    {
        private bool _upvoted;
        private bool _downvoted;

        public string Title { get; set; }
        public string Image { get; set; }
        public uint CommentCount { get; set; }
        public bool Upvoted
        {
            get
            {
                return _upvoted;
            }
            set
            {
                if (value == true && _upvoted == true)
                {
                    _upvoted = false;
                }
                else
                {
                    if (value == true)
                    {
                        _downvoted = false;
                    }
                    _upvoted = value;
                }
            }
        }
        public bool Downvoted
        {
            get
            {
                return _downvoted;
            }
            set
            {
                if (value == true && _downvoted == true)
                {
                    _downvoted = false;
                }
                else
                {
                    if (value == true)
                    {
                        _upvoted = false;
                    }
                    _downvoted = value;
                }
            }
        }
        // TODO: Add comments to this object.
    }
}
