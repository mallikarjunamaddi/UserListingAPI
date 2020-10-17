using System;

using UserListingAPI.DataModel;

namespace UserListingAPI.Repository.Mapper
{
	public class Mapper
	{
		/// <summary>
		/// UserMapper to convert DataModel Object to DomainModel Object
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
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

		/// <summary>
		/// UserMapper to convert DomainModel Object to DataModel Object
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
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
