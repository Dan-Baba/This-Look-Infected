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
                new Post{ Title = "Test Post", Image = "bruise.jpg", CommentCount = 42 },
                new Post{ Title = "Sweet Blist", Image = "blister.jpg", CommentCount = 105 }
            });

        public ObservableCollection<Post> Posts { get; set; }

        public HomeMasterDetailPageDetail()
        {
            InitializeComponent();

            Posts = new ObservableCollection<Post>();

            PostView.ItemsSource = Posts;

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


    }
}