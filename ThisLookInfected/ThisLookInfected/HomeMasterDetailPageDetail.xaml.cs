using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows.Input;

namespace ThisLookInfected
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterDetailPageDetail : ContentPage
    {
        const int TIMES_TO_LOOP_POSTS = 50;
        public ObservableCollection<Post> posts = new ObservableCollection<Post>(new[]
            {
                new Post{ Title = "Baseball Injury", Image = "bruise.jpg", CommentCount = 42, Upvoted = true, Downvoted = false },
                new Post{ Title = "Sweet Blist", Image = "blister.jpg", CommentCount = 105, Upvoted = false, Downvoted = true },
                new Post{ Title = "What's This?", Image = "petechiae.jpg", CommentCount = 2, Upvoted = false, Downvoted = false}
            });

        public ObservableCollection<Post> Posts { get; set; }

        public HomeMasterDetailPageDetail()
        {
            InitializeComponent();

            Posts = new ObservableCollection<Post>();

            PostView.ItemsSource = Posts;
            PostView.ItemTapped += TapGestureRecognizer_Tapped;

            LoadData();
        }

        public void LoadData()
        {
            Posts.Clear();
            foreach (Post post in posts)
            {
                Posts.Add(post);
            }
        }

        async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SinglePost((Post)PostView.SelectedItem));
            PostView.SelectedItem = null;
        }

        private void Upvote_Button_Pressed(object sender, EventArgs e)
        {
            Button button = (sender as Button);
            Post post = (button.CommandParameter as Post);
            post.Upvoted = true;

        }

        private void Downvote_Button_Pressed(object sender, EventArgs e)
        {
            ((sender as Button).CommandParameter as Post).Downvoted = true;
        }
    }
}