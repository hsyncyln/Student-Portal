using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.Controllers
{
	public class AdminController : BaseController
	{
		public IActionResult Home()
		{
			return RedirectToAction("Students","Student");
		}

		
	}
}
