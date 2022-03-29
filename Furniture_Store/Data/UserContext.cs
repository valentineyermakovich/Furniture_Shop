using System.Data.Entity;

namespace Furniture_Store.Data
{
	public class UserContext: DbContext
	{
		public UserContext() : base("DefaultConnection")
		{

		}

		public DbSet<User> Users { get; set; }
	}
}
