using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Medicabio.Models;
using SQLite;

namespace Medicabio.Data
{
    public class QuoteProductsDatabase
    {
        readonly SQLiteAsyncConnection database;

        public QuoteProductsDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<ProductItem>().Wait();
        }

        public Task<List<ProductItem>> GetProductItemsAsync()
        {
            Debug.WriteLine("get product items async sqlite");
            Debug.WriteLine(database.Table<ProductItem>().ToListAsync().ToString());
            return database.Table<ProductItem>().ToListAsync();
        }

        public Task<ProductItem> GetProductItemsAsync(int id)
        {
            return database.Table<ProductItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveProductItemAsync(ProductItem item)
        {
            Debug.WriteLine("Salvo prodotto " + item.Id);
            //if (item.Id != 0)
            //{
            //    return database.UpdateAsync(item);
            //}
            //else
            //{
            //    return database.InsertAsync(item);
            //}

            return database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(ProductItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}
