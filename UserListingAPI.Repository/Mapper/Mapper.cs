using System;

using UserListingAPI.DataModel;

namespace UserListingAPI.Repository.Mapper
{
	public class Mapper
	{
		public static DomainModel.User UserMapper(User user)
		{
			DomainModel.User userObj = new DomainModel.User()
			{
				Id = user.Id,
				Name = user.Name,
				Email = user.Email,
				RoleType = user.RoleType,
				Status = user.Status,
				MobileNumber = user.MobileNumber
			};
			return userObj;
		}

		public static User UserMapper(DomainModel.User user)
		{
			User userObj = new User()
			{
				Name = user.Name,
				Email = user.Email,
				RoleType = user.RoleType,
				Status = user.Status,
				MobileNumber = user.MobileNumber,
				CreatedAt = DateTime.UtcNow,
				ModifiedAt = DateTime.UtcNow
			};
			return userObj;
		}
	}
}
