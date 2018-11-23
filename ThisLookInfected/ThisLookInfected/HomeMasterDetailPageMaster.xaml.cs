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
        private Boolean _loginStatus = false;
        public Boolean LoginStatus
        {
            get
            {
                return _loginStatus;
            }
            set
            {
                if (value == _loginStatus)
                {
                    // If they're the same, we do nothing.
                }
                else if (value)
                {
                    // They are different and value is true, so user just logged in.
                    _loginStatus = true;
                    (BindingContext as HomeMasterDetailPageMasterViewModel).LogIn();
                }
                else
                {
                    _loginStatus = false;
                    (BindingContext as HomeMasterDetailPageMasterViewModel).LogOut();
                }
            }
        }

        public HomeMasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new HomeMasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        public HomeMasterDetailPageMaster(Boolean loginStatus)
        {
            InitializeComponent();
            BindingContext = new HomeMasterDetailPageMasterViewModel();
            LoginStatus = loginStatus;
            ListView = MenuItemsListView;
        }

        class HomeMasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomeMasterDetailPageMenuItem> MenuItems { get; set; }

            
            public HomeMasterDetailPageMasterViewModel()
            {
                LogOut();
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

            public void LogIn()
            {
                MenuItems = new ObservableCollection<HomeMasterDetailPageMenuItem>(new[]
                    {
                    new HomeMasterDetailPageMenuItem { Id = 0, Title = "This Look Infected?", LinkText = "Home", TargetType = typeof(HomeMasterDetailPageDetail) },
                    new HomeMasterDetailPageMenuItem { Id = 1, Title = "Account", TargetType = typeof(Account)},
                    new HomeMasterDetailPageMenuItem { Id = 2, Title = "New Post", TargetType = typeof(NewPost) },
                    new HomeMasterDetailPageMenuItem { Id = 3, Title = "Search", TargetType = typeof(Search) },
                    new HomeMasterDetailPageMenuItem { Id = 4, Title = "Settings", TargetType = typeof(Settings) },
                    new HomeMasterDetailPageMenuItem { Id = 5, Title = "Sign Out", TargetType = typeof(SignOut) }
                    });
                PropertyChanged(this, new PropertyChangedEventArgs("MenuItems"));
            }

            public void LogOut()
            {
                MenuItems = new ObservableCollection<HomeMasterDetailPageMenuItem>(new[]
                    {
                    new HomeMasterDetailPageMenuItem { Id = 0, Title = "This Look Infected?", LinkText = "Home", TargetType = typeof(HomeMasterDetailPageDetail) },
                    new HomeMasterDetailPageMenuItem { Id = 1, Title = "Login", TargetType = typeof(Login) },
                    new HomeMasterDetailPageMenuItem { Id = 2, Title = "Sign Up", TargetType = typeof(SignUp) },
                    new HomeMasterDetailPageMenuItem { Id = 3, Title = "New Post", TargetType = typeof(NewPost) },
                    new HomeMasterDetailPageMenuItem { Id = 4, Title = "Search", TargetType = typeof(Search) },
                    new HomeMasterDetailPageMenuItem { Id = 5, Title = "Settings", TargetType = typeof(Settings) }
                    });
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MenuItems"));
            }
        }
    }
}