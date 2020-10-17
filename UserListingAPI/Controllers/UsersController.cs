using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

using UserListingAPI.Business.BusinessContracts;


namespace UserListingAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserBusiness _userBusiness;
		private readonly ILogger<UsersController> _logger;

		public UsersController(IUserBusiness userBusiness, ILogger<UsersController> logger)
		{
			_logger = logger;
			_userBusiness = userBusiness;
		}

		// GET: api/Users
		[HttpGet]
		public ActionResult<DomainModel.User[]> GetUsers()
		{
			_logger.LogInformation("UsersController:GetUsers Start: {0}", DateTime.Now);

			IList<DomainModel.User> result = new List<DomainModel.User>();
			try
			{
				result = _userBusiness.GetUsers();
			}
			catch (Exception e)
			{
				_logger.LogError(e, "UsersController:GetUsers Failed: {1}", DateTime.Now);
			}

			_logger.LogInformation("UsersController:GetUsers End: {1}", DateTime.Now);
			return Ok(result);
		}

		// POST: api/Users
		[HttpPost]
		public ActionResult<DomainModel.User> PostUser(DomainModel.User user)
		{
			_logger.LogInformation("UsersController:PostUser: name: {0} Start: {1}", user.Name,  DateTime.Now);

			DomainModel.User result = new DomainModel.User();
			try
			{
				result = _userBusiness.AddUser(user);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "UsersController:PostUser:name: {0} Failed: {1}", user.Name, DateTime.Now);
			}
			_logger.LogInformation("UsersController.PostUser:name: {0} End: {1}", user.Name, DateTime.Now);

			return Ok(result);
		}

		// PATCH: api/Users
		[HttpPatch]
		public ActionResult<DomainModel.User> PatchUser(DomainModel.User user)
		{
			_logger.LogInformation("UsersController:PatchUser:Id: {0} Start: {1}", user.Id, DateTime.Now);

			DomainModel.User result = new DomainModel.User();
			try
			{
				result = _userBusiness.UpdateUser(user);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "UsersController:PatchUser:Id: {0} Failed: {1}", user.Id, DateTime.Now);
			}

			_logger.LogInformation("UsersController:PatchUser:Id: {0} End: {1}", user.Id, DateTime.Now);
			return Ok(result);
		}

		// PATCH: api/Users
		[HttpDelete("{id}")]
		public ActionResult<DomainModel.User> DeleteUser(int id)
		{
			_logger.LogInformation("UsersController:DeleteUser:Id: {0} Start: {1}", id, DateTime.Now);

			DomainModel.User result = new DomainModel.User();
			try
			{
				result = _userBusiness.DeleteUser(id);
			}
			catch (Exception e)
			{
				_logger.LogError(e, "UsersController:DeleteUser:Id: {0} Failed: {1}", id, DateTime.Now);
			}

			_logger.LogInformation("UsersController:DeleteUser:Id: {0} End: {1}", id, DateTime.Now);
			return Ok(result);
		}

	}
}
