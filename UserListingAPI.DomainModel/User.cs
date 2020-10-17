using System;

namespace UserListingAPI.DomainModel
{
	public class User : BaseDomainModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string RoleType { get; set; }
		public string Status { get; set; }
		public string MobileNumber { get; set; } 
	}
}
