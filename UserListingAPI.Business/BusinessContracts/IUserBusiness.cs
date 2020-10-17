using System.Collections.Generic;

using UserListingAPI.DomainModel;

namespace UserListingAPI.Business.BusinessContracts
{
	public interface IUserBusiness
	{
		IList<User> GetUsers();
		User AddUser(User user);
		User UpdateUser(User user);
		User DeleteUser(int id);
		string GenerateEmail(string name);
	}
}
