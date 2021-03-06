﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using Xamarin.Forms;

namespace HelloWorld.DataAccess
{
    public partial class SQLitePage : ContentPage
    {
        private readonly SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public SQLitePage()
        {
            InitializeComponent();

			 _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
			
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Recipe>();

            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);

            recipesListView.ItemsSource = _recipes;

            base.OnAppearing();
        }

        async void OnAdd(object sender, System.EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);

            _recipes.Add(recipe);
		}

		async void OnUpdate(object sender, System.EventArgs e)
		{
            var recipe = _recipes[0];
            recipe.Name += " Updated";

            await _connection.UpdateAsync(recipe);
        }

		async void OnDelete(object sender, System.EventArgs e)
		{
            var recipe = _recipes[0];
            await _connection.DeleteAsync(recipe);

            _recipes.Remove(recipe);
		}
	}

    [Table("Recipes")]
	public class Recipe : INotifyPropertyChanged
	{
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement, Column("RecipeId")]
		public int Id { get; set; }

        [MaxLength(255)]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name == value)
                    return;

                _name = value;

                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;

	}

}
