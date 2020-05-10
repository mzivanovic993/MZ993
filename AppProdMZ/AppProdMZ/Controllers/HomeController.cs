using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppProdMZ.Models;

namespace AppProdMZ.Controllers
{
	enum DataSource
	{
		DataBase,
		Json
	}

	public class HomeController : Controller
	{

		DataSource dataSource = DataSource.Json;
		static ProductModel model = null;

		public ActionResult Index()
		{
			if (dataSource == DataSource.DataBase && model == null)
			{
				Database.SetInitializer(new DropCreateDatabaseAlways<ProductsDataBase>());
				model = new ProductModel(new SqlRepository<Product>(new ProductsDataBase()));
			}
			else if (dataSource == DataSource.Json && model == null)
			{
				model = new ProductModel(new JsonRepository<Product>("input.json"));
				model.Dispose();
			}

			return View(model);
		}


		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Name,Description,Category,Producer,Supplier,Price")] Product product)
		{
			if (ModelState.IsValid)
			{
				model.AddProduct(product);
				return RedirectToAction("Index");
			}

			return View(product);
		}

	}
}