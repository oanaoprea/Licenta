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
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await ClientService.GetClient();
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClientListPage
            {
                BindingContext = new Client()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ClientListPage
                {
                    BindingContext = e.SelectedItem as Client
                });
            }
        }
    }
}