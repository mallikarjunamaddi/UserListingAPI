using System.Linq;
using System.Collections.Generic;

using UserListingAPI.DomainModel;
using UserListingAPI.DataModel.DBContext;
using UserListingAPI.Repository.RepositoryContracts;


namespace UserListingAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly UserDBContext _dbContext;

		public UserRepository(UserDBContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IList<User> GetAll()
		{
			List<User> users = new List<User>();

			var usersDbObj = _dbContext.Users.ToList();
			foreach (var userDbObj in usersDbObj)
			{
				var userObj = Mapper.Mapper.UserMapper(userDbObj);
				users.Add(userObj);
			}
			return users;
		}
		public User Add(User user)
		{
			var userDbObj = Mapper.Mapper.UserMapper(user);

			_dbContext.Users.Add(userDbObj);
			_dbContext.SaveChanges();
			return user;
		}

		public int GetNameCount(string name)
		{
			var result = _dbContext.Users.Where(user => user.Name == name).Count();
			return result;
		}
	}
}
