using System.Collections.Generic;

using UserListingAPI.DomainModel;

namespace UserListingAPI.Repository.RepositoryContracts
{
	public interface IUserRepository
	{
		IList<User> GetAll();
		User Add(User user);
		int GetNameCount(string name);
		User GetById(int id);
		User Update(User user);
		User Delete(int id);
	}
} 
