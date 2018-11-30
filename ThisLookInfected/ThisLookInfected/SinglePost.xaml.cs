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
        public Post Post { get; set; }

		public SinglePost ()
		{
			InitializeComponent ();
		}

        public SinglePost(Post post)
        {
            this.BindingContext = this;
            this.Post = post;
            InitializeComponent();
            BuildCommentSection();
        }

        private void Upvote_Button_Pressed(object sender, EventArgs e)
        {
            Post.Upvoted = true;

        }

        private void Downvote_Button_Pressed(object sender, EventArgs e)
        {
            Post.Downvoted = true;
        }

        private void BuildCommentSection()
        {
            /*
            <!-- Start Comment Section -->
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="50" />
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="75" />
                </Grid.ColumnDefinitions>
                <StackLayout Grid.Row="0" Grid.Column="0" Margin="5, 0, 0, 0">
                    <Label Text="Dan" />
                    <Label Text="10/2/2018" />
                </StackLayout>
                <Label Text="This is a comment that I have made!" Grid.Row="0" Grid.Column="1" />

                <BoxView Color="Gray" Grid.Row="1" Grid.Column="0" Margin="5, 5, 60, 5" />

            </Grid>
            */
            if (Post.Comments != null)
            {
                Post.Comments.ForEach(c => { ContentView.Children.Add(BuildComment(c)); });
            }
            // ContentView.Children.Add(grid);
        }

        private Grid BuildComment(Comment comment)
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });

            var stack = new StackLayout { Margin = new Thickness(5, 0, 0, 0) };
            stack.Children.Add(new Label { Text = comment.Name, LineBreakMode =  LineBreakMode.TailTruncation });
            stack.Children.Add(new Label { Text = comment.Date, FontSize = 7 });

            grid.Children.Add(stack, 0, 0);
            grid.Children.Add(new Label { Text = comment.CommentText }, 1, 0);

            if (comment.Responses != null)
            {
                grid.Children.Add(new BoxView { Color = Color.Gray, Margin = new Thickness(5, 5, 45, 5) }, 0, 1);
                var responses = new StackLayout();
                comment.Responses.ForEach(r => { responses.Children.Add(BuildComment(r)); });
                grid.Children.Add(responses, 1, 1);
            }

            return grid;
        }
    }
}