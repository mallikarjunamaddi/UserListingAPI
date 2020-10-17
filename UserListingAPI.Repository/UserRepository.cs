using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using UserListingAPI.DomainModel;
using UserListingAPI.DataModel.DBContext;
using UserListingAPI.Repository.RepositoryContracts;


namespace UserListingAPI.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly ILogger<UserRepository> _logger;
		private readonly UserDBContext _dbContext;

		public UserRepository(UserDBContext dbContext, ILogger<UserRepository> logger)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		public IList<User> GetAll()
		{
			_logger.LogInformation("UserRepository:GetAll Start: {0}", DateTime.Now);

			List<User> users = new List<User>();

			var usersDbObj = _dbContext.Users.ToList();
			foreach (var userDbObj in usersDbObj)
			{
				var userObj = Mapper.Mapper.UserMapper(userDbObj);
				users.Add(userObj);
			}

			_logger.LogInformation("UserRepository:GetAll End: {0}", DateTime.Now);
			return users;
		}
		public User Add(User user)
		{
			_logger.LogInformation("UserRepository:Add Start: {0}", DateTime.Now);

			var userDbObj = Mapper.Mapper.UserMapper(user);
			_dbContext.Users.Add(userDbObj);
			_dbContext.SaveChanges();

			_logger.LogInformation("UserRepository:Add End: {0}", DateTime.Now);
			return user;
		}

		public int GetNameCount(string name)
		{
			_logger.LogInformation("UserRepository:GetNameCount Start: {0}", DateTime.Now);

			var result = _dbContext.Users.Where(user => user.Name == name).Count();
			
			_logger.LogInformation("UserRepository:GetNameCount End: {0}", DateTime.Now);
			return result;
		}

		public User GetById(int id)
		{
			_logger.LogInformation("UserRepository:GetById Start: {0}", DateTime.Now);

			var result = new User();
			var userDbObj = _dbContext.Users.FirstOrDefault(user => user.Id == id);
			if (userDbObj != null)
			{
				result = Mapper.Mapper.UserMapper(userDbObj);
			}

			_logger.LogInformation("UserRepository:GetById End: {0}", DateTime.Now);
			return result;
		}

		public User Update(User user)
		{
			_logger.LogInformation("UserRepository:Update Start: {0}", DateTime.Now);

			var result = new User();
			var userDbObj = _dbContext.Users.FirstOrDefault(u => u.Id == user.Id);
			if (userDbObj != null)
			{
				UpdateUserRecord(userDbObj, user);
				_dbContext.SaveChanges();
				result = user;
			}

			_logger.LogInformation("UserRepository:Update End: {0}", DateTime.Now);
			return result;
		}

		public User Delete(int id)
		{
			_logger.LogInformation("UserRepository:Delete Start: {0}", DateTime.Now);

			var result = new User();
			var userDbObj = _dbContext.Users.FirstOrDefault(user => user.Id == id);
			if (userDbObj != null)
			{
				result = Mapper.Mapper.UserMapper(userDbObj);
				_dbContext.Users.Remove(userDbObj);
				_dbContext.SaveChanges();
			}

			_logger.LogInformation("UserRepository:Delete End: {0}", DateTime.Now);
			return result;
		}

		private void UpdateUserRecord(DataModel.User userDbObj, User user)
		{
			userDbObj.Name = user.Name;
			userDbObj.Email = user.Email;
			userDbObj.RoleType = user.RoleType;
			userDbObj.Status = user.Status;
			userDbObj.MobileNumber = user.MobileNumber;
			userDbObj.ModifiedAt = DateTime.UtcNow;
		}
	}
}
