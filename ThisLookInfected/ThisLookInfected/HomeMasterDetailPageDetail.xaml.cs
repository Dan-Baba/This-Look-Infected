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
        public ObservableCollection<Post> posts = new ObservableCollection<Post>(new[]
            {
                new Post
                {
                    Title = "Baseball Injury, Bruise",
                    Image = "bruise.jpg",
                    CommentCount = 42,
                    Upvoted = true,
                    Downvoted = false,
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Name = "Dan",
                            Date = "10/2/2018",
                            CommentText = "This is a comment that I have made!",
                            Responses = new List<Comment>
                            {
                                new Comment
                                {
                                    Name = "Toni",
                                    Date = "10/3/2018",
                                    CommentText = "GET OUT OF HERE!",
                                    Responses = new List<Comment>
                                    {
                                        new Comment
                                        {
                                            Name = "Dan",
                                            Date = "10/4/2018",
                                            CommentText = "Roger that.",
                                            Responses = null
                                        }
                                    }
                                }
                            }
                        },
                        new Comment
                        {
                            Name = "Mom",
                            Date = "10/2/2018",
                            CommentText = "Get well soon!",
                            Responses = null
                        }
                    }
                },
                new Post
                {
                    Title = "Sweet Blist",
                    Image = "blister.jpg",
                    CommentCount = 105,
                    Upvoted = false,
                    Downvoted = true,
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Name = "Mom",
                            Date = "10/20/2018",
                            CommentText = "Go to the HOSPITAL!",
                            Responses = null
                        }
                    }
                },
                new Post
                {
                    Title = "What's This?",
                    Image = "petechiae.jpg",
                    CommentCount = 2,
                    Upvoted = false,
                    Downvoted = false,
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Name = "Dr. Strange",
                            Date = "11/1/2018",
                            CommentText = "This is Petechiae, nothing to worry about.",
                            Responses = null
                        }
                    }
                }
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

        public HomeMasterDetailPageDetail(string searchText) : this()
        {
            this.Posts = new ObservableCollection<Post>(this.Posts.Where(p => p.Title.ToLower().Contains(searchText.ToLower())));
            PostView.ItemsSource = Posts;
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