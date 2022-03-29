using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class OrderContext: DbContext
	{
		public OrderContext() : base("DefaultConnection")
		{

		}

		public DbSet<Order> Orders { get; set; }
	}
}
