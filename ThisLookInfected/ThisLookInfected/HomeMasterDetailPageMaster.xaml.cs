using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ThisLookInfected
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeMasterDetailPageMaster : ContentPage
    {
        public ListView ListView;

        public HomeMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new HomeMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HomeMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomeMasterDetailPageMenuItem> MenuItems { get; set; }

            
            public HomeMasterDetailPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomeMasterDetailPageMenuItem>(new[]
                {
                new HomeMasterDetailPageMenuItem { Id = 0, Title = "This Look Infected?", LinkText = "Home", TargetType = typeof(HomeMasterDetailPageDetail) },
                new HomeMasterDetailPageMenuItem { Id = 1, Title = "Login", TargetType = typeof(Login) },
                new HomeMasterDetailPageMenuItem { Id = 2, Title = "Sign Up", TargetType = typeof(SignUp) },
                new HomeMasterDetailPageMenuItem { Id = 3, Title = "New Post", TargetType = typeof(NewPost) },
                new HomeMasterDetailPageMenuItem { Id = 4, Title = "Search", TargetType = typeof(Search) },
                new HomeMasterDetailPageMenuItem { Id = 5, Title = "Settings", TargetType = typeof(Settings) },
                new HomeMasterDetailPageMenuItem { Id = 6, Title = "Account", TargetType = typeof(Account)}
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}