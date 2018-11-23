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
	public partial class SignOut : ContentPage
	{
		public SignOut ()
		{
			InitializeComponent ();
            //Application.Current.MainPage = new HomeMasterDetailPage();
        }
        protected override void OnAppearing()
        {
            Application.Current.MainPage = new HomeMasterDetailPage();
            base.OnAppearing();

        }
    }
}