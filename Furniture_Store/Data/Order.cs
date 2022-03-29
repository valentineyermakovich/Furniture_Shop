using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class Order
	{
		public int ID { get; set; }

		public decimal Cost { get; set; }

		public int Customer { get; set; }

		public bool? Is_Approved { get; set; }
	}
}
