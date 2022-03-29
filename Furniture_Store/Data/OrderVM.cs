using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class OrderVM
	{
		public int ID { get; set; }

		public decimal Cost { get; set; }

		public int Customer { get; set; }

		public string Address { get; set; }

		public bool ApproveVisible { get; set; }

		public string Phone { get; set; }

		public bool? Is_Approved { get; set; }
		public string EMail { get; set; }
		public string Delivery { get; set; }

	}
}
