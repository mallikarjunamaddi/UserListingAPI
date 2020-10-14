using System;
using System.Collections.Generic;
using System.Text;

namespace UserListingAPI.DataModel
{
	public class BaseDBModel
	{
		public int Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; } 
	}
}
