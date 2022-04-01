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
    public partial class WorkoutListPage : ContentPage
    {
        public WorkoutListPage()
        {
            InitializeComponent();
        }


        async void OnSaveButtonClicked(object sender, EventArgs e)
        {

            var workout = (Workout)BindingContext;
            await WorkoutService.SaveWorkout(workout);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {

            var workout = (Workout)BindingContext;
            await WorkoutService.RemoveWorkout(workout.Id);
            await Navigation.PopAsync();
        }
    }
}