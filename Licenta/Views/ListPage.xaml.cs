using Licenta.Models;
using Licenta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Licenta.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var recipie = (Recipie)BindingContext;
            await RecipieService.SaveRecipie(recipie);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            var recipie = (Recipie)BindingContext;
            await RecipieService.RemoveRecipie(recipie.Id);
            await Navigation.PopAsync();
        }

    }
}