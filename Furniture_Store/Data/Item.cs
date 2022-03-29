using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class Item
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public string Item_Type { get; set; }

		public decimal Cost { get; set; }

		public DateTime Date_Of_Add { get; set; }

		public byte[] Image { get; set; }

		public int Amount { get; set; }
	}
}
