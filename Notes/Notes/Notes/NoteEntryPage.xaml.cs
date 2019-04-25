using Notes.Models;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Notes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NoteEntryPage : ContentPage
	{
		public NoteEntryPage ()
		{
			InitializeComponent ();
		}

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            Note note = base.BindingContext as Note;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);

            await Navigation.PopAsync();
        }
        private async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            Note note = base.BindingContext as Note;
            await App.Database.DeleteNoteAsync(note);

            await Navigation.PopAsync();
        }
    }
}