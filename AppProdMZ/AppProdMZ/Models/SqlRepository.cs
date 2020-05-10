using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppProdMZ.Models
{
	public class ProductsDataBase : DbContext
	{
		public DbSet<Product> Products { get; set; }
	}

	public class SqlRepository<T> : IReposotory<T> where T : class
	{
		DbContext _database;
		DbSet<T> _set;

		public SqlRepository(DbContext database)
		{
			this._database =  database;
			_set = database.Set<T>();
		}

		public void Add(T newEntity)
		{
			_set.Add(newEntity);
			Commit();
		}

		public int Commit()
		{
			return _database.SaveChanges();
		}

		public void Delete(T entity)
		{
			_set.Remove(entity);
		}

		public void Dispose()
		{
			_database.Dispose();
		}

		public IQueryable<T> FindAll()
		{
			return _set;
		}

		public T FindOutById(int id)
		{
			return _set.Find(id);
		}
	}
}