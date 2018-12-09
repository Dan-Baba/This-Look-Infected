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
	public partial class Settings : ContentPage
	{
		public Settings ()
		{
			InitializeComponent ();

            //Items for the Page Sort
            PickerPage.Items.Add("Hot");
            PickerPage.Items.Add("Rising");
            PickerPage.Items.Add("New");
            PickerPage.SelectedIndex = 0;
            //Items for the comment sort
            PickerCom.Items.Add("Hot");
            PickerCom.Items.Add("New");
            PickerCom.SelectedIndex = 0;
            //Items for langauge
            PickerLang.Items.Add("English");
            PickerLang.Items.Add("Spanish");
            PickerLang.SelectedIndex = 0;


        }
    
        //Class for showing picked value for page
        private void PickerPage_OnSelectedIndexChanged(object sender, EventArgs args)
        {
            var name = PickerPage.Items[PickerPage.SelectedIndex];
           
        }
        //Class for showing picked value for comments
        private void PickerCom_OnSelectedIndexChanged(object sender, EventArgs args)
        {
            var name = PickerCom.Items[PickerCom.SelectedIndex];

        }
        //For Langauge
        private void PickerLang_OnSelectedIndexChanged(object sender, EventArgs args)
        {
            var name = PickerLang.Items[PickerLang.SelectedIndex];

        }
    }
}