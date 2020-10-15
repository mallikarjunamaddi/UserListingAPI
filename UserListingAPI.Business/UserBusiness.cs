using System.Collections.Generic;
using UserListingAPI.Business.BusinessContracts;
using UserListingAPI.DataModel;
using UserListingAPI.Repository.RepositoryContracts;

namespace UserListingAPI.Business
{
	public class UserBusiness : IUserBusiness
	{
		private readonly IUserRepository _userRepository;

		public UserBusiness(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		public DomainModel.User AddUser(DomainModel.User user)
		{
			var result = _userRepository.Add(user);
			return result;
		}

		public IList<DomainModel.User> GetUsers()
		{
			var result = _userRepository.GetAll();
			return result;
		}
	}
}
