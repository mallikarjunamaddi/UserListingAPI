using System.ComponentModel.DataAnnotations;

namespace UserListingAPI.DataModel
{
	public class User : BaseDBModel
	{
		[Required, StringLength(100)]
		public string Name { get; set; }
		[Required, StringLength(100)]
		public string Email { get; set; }
		[Required, StringLength(50)]
		public string RoleType { get; set; }
		[Required, StringLength(50)]
		public string Status { get; set; }
		[StringLength(12, MinimumLength = 12, ErrorMessage = "This Phone pattern is ###-###-####")]
		public string MobileNumber { get; set; }
	}
}
