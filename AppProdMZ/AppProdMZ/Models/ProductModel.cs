using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace AppProdMZ.Models
{
	public class ProductModel
	{
		#region Enum

		#endregion Enum

		IReposotory<Product> products;


		public ProductModel(IReposotory<Product> products)
		{
			this.products = products;
		}

		public void AddProduct(Product product)
		{
			products.Add(product);
		}

		public bool SaveProduct(int? id)
		{
			return true;
		}

		public void DeleteProduct(int id)
		{
			products.Delete(products.FindOutById(id));
		}

		public List<Product> ShowAllProduct()
		{
			var set = products.FindAll();
			if (set != null && set.Count() != 0)
				return set.ToList();
			else
				return new List<Product>();
		}

		public void Dispose()
		{
			products.Dispose();
		}
	}
}