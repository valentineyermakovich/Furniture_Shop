using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	[Table("Order_Items")]
	public class Order_Item
	{
		public int ID { get; set; }
		public int Item_ID { get; set; }
		public int Order_ID { get; set; }
	}
}
