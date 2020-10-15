using Microsoft.AspNetCore.Mvc;

using UserListingAPI.Business.BusinessContracts;


namespace UserListingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
		private readonly IUserBusiness _userBusiness;

		public UsersController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<DomainModel.User[]> GetUsers()
        {
			var result = _userBusiness.GetUsers(); 
			return Ok(result);
        }

		// POST: api/Users
		[HttpPost]
		public ActionResult<DomainModel.User> PostUser(DomainModel.User user)
		{
			var result = _userBusiness.AddUser(user);
			return Ok(result);
		}

		// PATCH: api/Users
		[HttpPatch]
		public ActionResult<DomainModel.User> PatchUser(DomainModel.User user)
		{
			var result = _userBusiness.UpdateUser(user);
			return Ok(result);
		}

	}
}
