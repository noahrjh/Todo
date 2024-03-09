using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Todo.Models;
namespace Todo.Views
{
    public partial class TodoItemPage : ContentPage
    {
        public TodoItemPage()
        {
            InitializeComponent();
        }
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            // TodoItemDatabase database = await TodoItemDatabase.Instance;
            await App.Database.SaveItemAsync(todoItem);
            await Navigation.PopAsync();
        }
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            //TodoItemDatabase database = await TodoItemDatabase.Instance;
            await App.Database.DeleteItemAsync(todoItem);
            await Navigation.PopAsync();
        }
        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
