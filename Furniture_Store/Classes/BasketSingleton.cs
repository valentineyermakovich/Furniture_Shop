using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Furniture_Store.Data;

namespace Furniture_Store.Classes
{
	public class BasketSingleton
	{
		public List<Item> Items { get; set; }

		private static BasketSingleton instance;

		private BasketSingleton()
		{

		}

		public static BasketSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new BasketSingleton();
				instance.Items = new List<Item>();
			}
			return instance;
		}

		public static void RemoveItemsFromBasket()
		{
			BasketSingleton.instance.Items.Clear();
		}
	}
}
