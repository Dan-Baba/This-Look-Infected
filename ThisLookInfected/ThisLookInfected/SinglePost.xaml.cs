using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThisLookInfected
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SinglePost : ContentPage
	{
        //public Post Post { get; set; }
        public string image = "";
        public uint commentCount = 0;
		public SinglePost ()
		{
			InitializeComponent ();
		}

        public SinglePost(Post post)
        {
            this.image = post.Image;
            this.commentCount = post.CommentCount;
            InitializeComponent();
        }
	}
}