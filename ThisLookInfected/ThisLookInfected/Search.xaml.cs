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
	public partial class Search : ContentPage
	{
		public Search ()
		{
			InitializeComponent ();
		}

        async void Button_Pressed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomeMasterDetailPageDetail(SearchBox.Text));
        }
    }
}