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
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
            ForgotPassword.GestureRecognizers.Add(new TapGestureRecognizer((view) => OnLabelClicked()));
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new HomeMasterDetailPage(true);
        }

        private void OnLabelClicked()
        {
            DisplayAlert("Forgot Password",
                "If the email you have entered is in our records we will email you account recovery information. Please check your email for more information.",
                "OK");
        }
    }
}