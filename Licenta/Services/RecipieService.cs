using Licenta.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Services
{
    public static class RecipieService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyRecipies.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Recipie>();

        }

        public static async Task AddRecipie(string name, string ingredients, string calories)
        {
            await Init();
            var recipie = new Recipie
            {
                Name = name,
                Ingredients = ingredients,
                Calories = calories
            };

            var id = await db.InsertAsync(recipie);
        }

        public static async Task RemoveRecipie (int id)
        {
            await Init();
            db.DeleteAsync<Recipie>(id);
        }

        public static async Task<List<Recipie>> GetRecipie ()
        {
            await Init();
            var recipie = await db.Table<Recipie>().ToListAsync();
            return recipie;
        }

        public static async Task<List<string>> GetRecipieName()
        {
            await Init();
            List<Recipie> recs = await GetRecipie();
            List<string> recname = null;
            foreach (var r in recs)
                recname.Add(r.Name);
            return recname;
        }

        public static Task<int> SaveRecipie(Recipie recipie)
        {
            if (recipie.Id != 0)
            {
                return db.UpdateAsync(recipie);
            }
            else
            {
                return db.InsertAsync(recipie);
            }
        }

    }
}
