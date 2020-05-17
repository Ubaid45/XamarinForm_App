using System;
using System.Collections.Generic;
using HelloWorld.Models;
using SQLite;
using Xamarin.Forms;

namespace HelloWorld.Exercises.FormsandSettingsPage.ContactBookWithSQLite
{
    public partial class ContactDetailsPage : ContentPage
    {
		public event EventHandler<SQLiteContact> ContactAdded;
		public event EventHandler<SQLiteContact> ContactUpdated;

		private SQLiteAsyncConnection _connection;

		public ContactDetailsPage(SQLiteContact contact)
		{
			if (contact == null)
				throw new ArgumentNullException(nameof(contact));

			InitializeComponent();

			_connection = DependencyService.Get<ISQLiteDb>().GetConnection();

			BindingContext = new SQLiteContact
			{
				Id = contact.Id,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Phone = contact.Phone,
				Email = contact.Email,
				IsBlocked = contact.IsBlocked
			};
		}

		async void OnSave(object sender, System.EventArgs e)
		{
			var contact = BindingContext as SQLiteContact;

			if (String.IsNullOrWhiteSpace(contact.FullName))
			{
				await DisplayAlert("Error", "Please enter the name.", "OK");
				return;
			}

			if (contact.Id == 0)
			{
				await _connection.InsertAsync(contact);

				ContactAdded?.Invoke(this, contact);
			}
			else
			{
				await _connection.UpdateAsync(contact);

				ContactUpdated?.Invoke(this, contact);
			}

			await Navigation.PopAsync();
		}
	}

}
