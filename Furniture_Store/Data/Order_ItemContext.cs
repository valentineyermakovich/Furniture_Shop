using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class Order_ItemContext: DbContext
	{
		public Order_ItemContext() : base("DefaultConnection")
		{

		}

		public DbSet<Order_Item> Order_Items { get; set; }
	}
}