using KUSYS.Core.Helper;
using KUSYS.Core.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.Controllers
{
	public class UserController : BaseController
	{
		private IStudentService _studentService;
		public UserController(IStudentService studentService) => _studentService = studentService;
		public IActionResult Home()
		{
			var userId = GlobalHelper.UserDto?.Id;
			if(userId == null)
				return RedirectToAction("Index", "Home");

			var studentId = _studentService.GetStudentIdByUserId((int)userId);
			return RedirectToAction("CourseManager", "Course", new { studentId = studentId });
		}
	}
}
