using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class ItemContext : DbContext
	{
		public ItemContext() : base("DefaultConnection")
		{

		}

		public DbSet<Item> Items { get; set; }
	}
}
