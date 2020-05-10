using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppProdMZ.Models
{
	public class Product
	{
		static int nextSequence;

		[Key]
		[JsonProperty("Id")]
		public int Id { get; private set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Description")]
		public string Description { get; set; }

		[JsonProperty("Category")]
		public string Category { get; set; }

		[JsonProperty("Producer")]
		public string Producer { get; set; }

		[JsonProperty("Supplier")]
		public string Supplier { get; set; }

		[JsonProperty("Price")]
		public decimal Price { get; set; }

		public Product() {
			Id = ++nextSequence;
		}
	}
}