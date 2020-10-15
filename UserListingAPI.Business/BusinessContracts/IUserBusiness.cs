using System.Collections.Generic;

using UserListingAPI.DomainModel;

namespace UserListingAPI.Business.BusinessContracts
{
	public interface IUserBusiness
	{
		IList<User> GetUsers();
		User AddUser(User user);
	}
}
