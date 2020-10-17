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
		#region Properties
		private readonly UserDBContext _dbContext;
		private readonly ILogger<UserRepository> _logger;
		#endregion

		#region Constructor
		public UserRepository(UserDBContext dbContext, ILogger<UserRepository> logger)
		{
			_logger = logger;
			_dbContext = dbContext;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Gets all the User records from Database
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Adds a new User record to User table.
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public User Add(User user)
		{
			_logger.LogInformation("UserRepository:Add Start: {0}", DateTime.Now);

			var userDbObj = Mapper.Mapper.UserMapper(user);
			_dbContext.Users.Add(userDbObj);
			_dbContext.SaveChanges();

			_logger.LogInformation("UserRepository:Add End: {0}", DateTime.Now);
			return user;
		}

		/// <summary>
		/// Returns record count with same name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public int GetNameCount(string name)
		{
			_logger.LogInformation("UserRepository:GetNameCount Start: {0}", DateTime.Now);

			var result = _dbContext.Users.Where(user => user.Name == name).Count();
			
			_logger.LogInformation("UserRepository:GetNameCount End: {0}", DateTime.Now);
			return result;
		}

		/// <summary>
		/// Returns User record based on id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Updates an Existing User record
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Delete an Existing User record
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
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
		#endregion

		#region Private Methods
		/// <summary>
		/// Maps the changes/updates to User DB Object 
		/// </summary>
		/// <param name="userDbObj"></param>
		/// <param name="user"></param>
		private void UpdateUserRecord(DataModel.User userDbObj, User user)
		{
			userDbObj.Name = user.Name;
			userDbObj.Email = user.Email;
			userDbObj.RoleType = user.RoleType;
			userDbObj.Status = user.Status;
			userDbObj.MobileNumber = user.MobileNumber;
			userDbObj.ModifiedAt = DateTime.UtcNow;
		}
		#endregion
	}
}
