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

    public partial class ClientListPage : ContentPage
    {



        public ClientListPage()
        {
            InitializeComponent();
            var picker = new Picker { Title = "Meal 1", TitleColor = Color.Red };
            picker.SetBinding(Picker.ItemsSourceProperty, "Recipie");
            picker.ItemDisplayBinding = new Binding("Name");
            Content = new StackLayout
            {
                Children =
                {
                    picker
                }
            };
        }


            async void OnSaveButtonClicked(object sender, EventArgs e)
            {

                var client = (Client)BindingContext;
                await ClientService.SaveClient(client);
                await Navigation.PopAsync();
            }
            async void OnDeleteButtonClicked(object sender, EventArgs e)
            {

                var client = (Client)BindingContext;
                await ClientService.RemoveClient(client.Id);
                await Navigation.PopAsync();
            }
        }
    }
