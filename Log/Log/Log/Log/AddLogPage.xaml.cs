using Log.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Log
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddLogPage : ContentPage
	{
        public AddLogPage()
        {
            InitializeComponent();
        }

        private async void SaveBtn_Clicked(object sender, EventArgs e)
        {
            LogContentModel log = base.BindingContext as LogContentModel;
            App.Logger.Debug(log.LogContent);

            await Navigation.PopAsync();
        }
    }
}