﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Furniture_Store.Data
{
	public class User
	{
		public int ID { get; set; }

		public string Name { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public int Role { get; set; }

		public string Address { get; set; }

		public string Phone_Number { get; set; }

		public string Mail { get; set; }
	}
}
