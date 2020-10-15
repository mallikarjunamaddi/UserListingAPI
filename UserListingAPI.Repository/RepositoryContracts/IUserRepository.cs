using System.Collections.Generic;

using UserListingAPI.DomainModel;

namespace UserListingAPI.Repository.RepositoryContracts
{
	public interface IUserRepository
	{
		IList<User> GetAll();
		User Add(User user);
		int GetNameCount(string name);
	}
}
