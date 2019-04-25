using Log.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Log
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LogEntryPage : ContentPage
	{
        public LogEntryPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            base.BindingContext = new LogContentModel
            {
                LogContent = App.Logger.ReadLog()
            };
        }
        private async void OnAddLog_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddLogPage
            {
                BindingContext = new LogContentModel()
            });
        }
    }
}