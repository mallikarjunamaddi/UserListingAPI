using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using UserListingAPI.DomainModel;
using UserListingAPI.Business.BusinessContracts;
using UserListingAPI.Repository.RepositoryContracts;

namespace UserListingAPI.Business
{
	public class UserBusiness : IUserBusiness
	{
		private readonly ILogger<UserBusiness> _logger;
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration;

		public UserBusiness(IUserRepository userRepository,
							IConfiguration configuration,
							ILogger<UserBusiness> logger)
		{
			_logger = logger;
			_userRepository = userRepository;
			_configuration = configuration;
		}

		public User AddUser(User user)
		{
			_logger.LogInformation("UserBusiness:AddUser Start: {0}", DateTime.Now);

			user.Email = GenerateEmail(user.Name);
			var result = _userRepository.Add(user);

			_logger.LogInformation("UserBusiness:AddUser End: {0}", DateTime.Now);
			return result;
		}

		public IList<User> GetUsers()
		{
			_logger.LogInformation("UserBusiness:GetUsers Start: {0}", DateTime.Now);

			var result = _userRepository.GetAll();

			_logger.LogInformation("UserBusiness:GetUsers End: {0}", DateTime.Now);
			return result;
		}

		public User UpdateUser(User user)
		{
			_logger.LogInformation("UserBusiness:UpdateUser Start: {0}", DateTime.Now);

			var result = new User();
			var existingUser = _userRepository.GetById(user.Id);
			if (existingUser != null)
			{
				if (existingUser.Name != user.Name)
				{
					user.Email = GenerateEmail(user.Name);
				}
				result = _userRepository.Update(user);
			}

			_logger.LogInformation("UserBusiness:UpdateUser End: {0}", DateTime.Now);
			return result;
		}

		public User DeleteUser(int id)
		{
			_logger.LogInformation("UserBusiness:DeleteUser Start: {0}", DateTime.Now);

			var result = _userRepository.Delete(id);

			_logger.LogInformation("UserBusiness:DeleteUser End: {0}", DateTime.Now);
			return result;
		}

		private string GenerateEmail(string name)
		{
			_logger.LogInformation("UserBusiness:GenerateEmail Start: {0}", DateTime.Now);

			var email = name;
			var count = GetNameCount(name);
			var emailDomain = _configuration["EmailDomain"];
			if (count != 0)
			{
				email += count.ToString();
			}

			email += "@" + emailDomain;

			_logger.LogInformation("UserBusiness:GenerateEmail End: {0}", DateTime.Now);
			return email;
		}

		private int GetNameCount(string name)
		{
			_logger.LogInformation("UserBusiness:GetNameCount Start: {0}", DateTime.Now);

			var result = _userRepository.GetNameCount(name);

			_logger.LogInformation("UserBusiness:GetNameCount End: {0}", DateTime.Now);
			return result;
		}
	}
}
