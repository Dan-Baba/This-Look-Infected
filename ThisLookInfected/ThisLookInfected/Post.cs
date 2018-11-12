using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ThisLookInfected
{
    public class Post: INotifyPropertyChanged
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

                if (value && _upvoted)
                {
                    _upvoted = false;
                }
                else
                {
                    if (value)
                    {
                        Downvoted = false;
                    }
                    _upvoted = value;
                }

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Upvoted"));
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
                        Upvoted = false;
                    }
                    _downvoted = value;
                }

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Downvoted"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // TODO: Add comments to this object.
    }
}
