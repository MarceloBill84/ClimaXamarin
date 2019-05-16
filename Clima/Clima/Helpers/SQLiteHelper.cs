using Clima.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Clima.Helpers
{
    public class SQLiteHelper
    {
		SQLiteAsyncConnection db;
		public SQLiteHelper(string dbPath)
		{
			db = new SQLiteAsyncConnection(dbPath);
			db.CreateTableAsync<CidadeFavorita>().Wait();
		}

		public Task<int> SaveItemAsync(CidadeFavorita cidade)
		{
			return db.InsertOrReplaceAsync(cidade);
		}

		public Task<int> DeleteItemAsync(CidadeFavorita cidade)
		{
			return db.DeleteAsync(cidade);
		}

		public Task<List<CidadeFavorita>> GetItemsAsync()
		{
			return db.Table<CidadeFavorita>().ToListAsync();
		}
		
		public Task<CidadeFavorita> GetItemAsync(int codigo)
		{
			return db.Table<CidadeFavorita>().FirstOrDefaultAsync(i => i.codigo == codigo);
		}
	}
}
