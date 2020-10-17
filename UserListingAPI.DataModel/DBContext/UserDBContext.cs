using Microsoft.EntityFrameworkCore;

namespace UserListingAPI.DataModel.DBContext
{
	public class UserDBContext : DbContext
	{
		public UserDBContext(DbContextOptions<UserDBContext> options):base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Log> Log { get; set; } 
	}
}
