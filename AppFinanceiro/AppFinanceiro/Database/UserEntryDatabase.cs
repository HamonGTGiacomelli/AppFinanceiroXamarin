using AppFinanceiro.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppFinanceiro.Database
{
    class UserEntryDatabase
    {
        readonly SQLiteAsyncConnection database;

        public UserEntryDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<UserEntry>().Wait();
        }

        public Task<List<UserEntry>> GetUserEntries ()
        {
            return database.Table<UserEntry>().ToListAsync();
        }

        public Task<UserEntry> GetUserEntry(uint id)
        {
            return database.Table<UserEntry>().Where(item => item.id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserEntry (UserEntry userEntry)
        {
            if (userEntry.id == 0)
            {
                return database.InsertAsync(userEntry);
            }
            return database.UpdateAsync(userEntry);
        }

        public Task<int> DeleteUserEntry (UserEntry userEntry)
        {
            return database.DeleteAsync(userEntry);
        }
    }
}
