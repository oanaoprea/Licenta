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
    public partial class WorkoutPage : ContentPage
    {
        public WorkoutPage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await WorkoutService.GetWorkout();
        }

        async void OnToolbarItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new WorkoutListPage
            {
                BindingContext = new Workout()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new WorkoutListPage
                {
                    BindingContext = e.SelectedItem as Workout
                });
            }
        }

    }
}