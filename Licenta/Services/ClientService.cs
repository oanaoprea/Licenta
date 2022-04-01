using Licenta.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Licenta.Services
{
    class ClientService
    {
        static SQLiteAsyncConnection db;
        static async Task Init()
        {
            if (db != null)
                return;

            // Get an absolute path to the database file
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyClients.db");

            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<Client>();

        }

        public static async Task AddClient(string name, string meal1)
        {
            await Init();
            var client = new Client
            {
                Name = name,
                Meal1 = meal1

            };

            var id = await db.InsertAsync(client);
        }

        public static async Task RemoveClient(int id)
        {
            await Init();
            db.DeleteAsync<Client>(id);
        }

        public static async Task<List<Client>> GetClient()
        {
            await Init();
            var client = await db.Table<Client>().ToListAsync();
            return client;
        }



        public static Task<int> SaveClient(Client client)
        {
            if (client.Id != 0)
            {
                return db.UpdateAsync(client);
            }
            else
            {
                return db.InsertAsync(client);
            }
        }
    }
}
