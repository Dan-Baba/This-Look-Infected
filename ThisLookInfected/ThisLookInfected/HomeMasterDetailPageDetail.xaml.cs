using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThisLookInfected
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterDetailPageDetail : ContentPage
    {
        public ObservableCollection<Post> posts = new ObservableCollection<Post>();

        public HomeMasterDetailPageDetail()
        {
            InitializeComponent();

            PostView.ItemsSource = posts;

            posts.Add(new Post { Title = "Test Post", Image = "bruise.jpg", CommentCount = 42 });
        }
    }
}