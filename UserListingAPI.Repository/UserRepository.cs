using System;
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

		public User GetById(int id)
		{
			var result = new User();
			var userDbObj = _dbContext.Users.FirstOrDefault(user => user.Id == id);
			if (userDbObj != null)
			{
				result = Mapper.Mapper.UserMapper(userDbObj);
			}
			return result;
		}

		public User Update(User user)
		{
			var result = new User();
			var userDbObj = _dbContext.Users.FirstOrDefault(user => user.Id == user.Id);
			if (userDbObj != null)
			{
				UpdateUserRecord(userDbObj, user);
				_dbContext.SaveChanges();
				result = user;
			}
			return result;
		}

		private void UpdateUserRecord(DataModel.User userDbObj, User user)
		{
			userDbObj.Name = user.Name;
			userDbObj.Email = user.Email;
			userDbObj.RoleType = user.RoleType;
			userDbObj.Status = user.Status;
			userDbObj.ModifiedAt = DateTime.UtcNow;
		}
	}
}
