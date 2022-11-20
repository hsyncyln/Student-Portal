using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.Controllers
{
	public class UserController : BaseController
	{
		public IActionResult Home()
		{
			return View();
		}
	}
}
