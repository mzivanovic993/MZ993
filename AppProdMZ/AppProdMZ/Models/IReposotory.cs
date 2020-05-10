using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppProdMZ.Models
{
	public interface IReposotory<T> : IDisposable
	{
		void Add(T newEntity);
		void Delete(T entity);
		IQueryable<T> FindAll();
		int Commit();
		T FindOutById(int id);
	}
}