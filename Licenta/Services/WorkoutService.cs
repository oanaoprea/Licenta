using Licenta.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Services
{
    public static class WorkoutService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyWorkouts.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Workout>();

        }

        public static async Task AddWorkout(string name, string description, string duration, string caloriesburnt)
        {
            await Init();
            var workout = new Workout
            {
                Name = name,
                Description = description,
                Duration = duration,
                CaloriesBurnt = caloriesburnt
            };

            var id = await db.InsertAsync(workout);
        }

        public static async Task RemoveWorkout(int id)
        {
            await Init();
            db.DeleteAsync<Workout>(id);
        }

        public static async Task<List<Workout>> GetWorkout()
        {
            await Init();
            var workout = await db.Table<Workout>().ToListAsync();
            return workout;
        }



        public static Task<int> SaveWorkout(Workout workout)
        {
            if (workout.Id != 0)
            {
                return db.UpdateAsync(workout);
            }
            else
            {
                return db.InsertAsync(workout);
            }
        }
    }
}
