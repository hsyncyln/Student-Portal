using KUSYS.Core.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.Controllers
{
    public class CourseController : BaseController
	{
		private ICourseService _courseService;
		public CourseController(ICourseService courseService) => _courseService = courseService;

		public PartialViewResult StudentCoursePartial(int studentId)
		{
			var studentCourses = _courseService.GetStudentCourses(studentId);
			return PartialView("_StudentCourses", studentCourses);
		}

		public IActionResult CourseManager(int studentId)
		{
			ViewBag.StudentId = studentId;
			return View();
		}
		public PartialViewResult SelectedCourseManagePartial(int studentId)
		{
			ViewBag.StudentId = studentId;
			var studentCourses = _courseService.GetStudentCourses(studentId);
			return PartialView("_SelectedCourseManagePartial", studentCourses);
		}
		public PartialViewResult SelectableCourseManagePartial(int studentId)
		{
			ViewBag.StudentId = studentId;
			var studentCourses = _courseService.GetSelectableCourses(studentId);
			return PartialView("_SelectableCourseManagePartial", studentCourses);
		}

		[HttpPost]
		public JsonResult AddSelectableCourse(int studentId, int courseId)
		{
			_courseService.AddSelectableCourse(studentId,courseId);
			return new JsonResult(new { Result = true, Message = "" });
		}

		[HttpPost]
		public JsonResult RemoveSelectedCourse(int studentId, int courseId)
		{
			_courseService.RemoveSelectedCourse(studentId, courseId);
			return new JsonResult(new { Result = true, Message = "" });
		}
	}
}
