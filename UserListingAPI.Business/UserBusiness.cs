using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

using UserListingAPI.DomainModel;
using UserListingAPI.Business.BusinessContracts;
using UserListingAPI.Repository.RepositoryContracts;

namespace UserListingAPI.Business
{
	public class UserBusiness : IUserBusiness
	{
		private readonly IUserRepository _userRepository;
		private readonly IConfiguration _configuration;

		public UserBusiness(IUserRepository userRepository, IConfiguration configuration)
		{
			_userRepository = userRepository;
			_configuration = configuration;
		}

		public User AddUser(User user)
		{
			user.Email = GenerateEmail(user.Name);
			var result = _userRepository.Add(user);
			return result;
		}

		public IList<User> GetUsers()
		{
			var result = _userRepository.GetAll();
			return result;
		}

		private string GenerateEmail(string name)
		{
			var email = name;
			var count = GetNameCount(name);
			var emailDomain = _configuration["EmailDomain"];
			if (count != 0)
			{
				email += count.ToString();
			}

			email += "@" + emailDomain;
			return email;
		}

		private int GetNameCount(string name)
		{
			var result = _userRepository.GetNameCount(name);
			return result;
		}
	}
}
