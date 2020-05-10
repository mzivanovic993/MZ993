using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AppProdMZ.Models
{
	public class JsonRepository<T> : IReposotory<T> where T :Product
	{
		string jsonDocument;
		List<T> list = new List<T>();

		string path = HttpContext.Current.Server.MapPath("~/App_Data/");

		public JsonRepository(string jsonFile)
		{
			jsonDocument = path + jsonFile;
		}

		public List<T> JsonObjects
		{
			get
			{
				string json = System.IO.File.ReadAllText(jsonDocument);
				list = JsonConvert.DeserializeObject<List<T>>(json);
				return list;
			}
		}

		public void Add(T newEntity)
		{
			list.Add(newEntity);
			Commit();
		}

		public int Commit()
		{
			string objjsonData = JsonConvert.SerializeObject(list, Formatting.Indented);
			System.IO.File.WriteAllText(jsonDocument, objjsonData);
			return 1;
		}

		public void Delete(T entity)
		{
			list.Remove(entity);
			Commit();
		}

		public void Dispose()
		{
			string objjsonData = JsonConvert.SerializeObject(new List<T>());
			System.IO.File.WriteAllText(jsonDocument, objjsonData);
		}

		public IQueryable<T> FindAll()
		{
			return JsonObjects.AsQueryable();
		}


 		public T FindOutById(int id)
		{
			return JsonObjects.Where(item => item.Id == id).Select(item => item).First();
		}
	}
}