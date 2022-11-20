using KUSYS.Core.Dto;
using KUSYS.Core.Implementations;
using KUSYS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KUSYS.Web.Controllers
{
    public class StudentController : BaseController
    {
        private IStudentService _studentService;
        public StudentController(IStudentService studentService) => _studentService = studentService;
        
        public IActionResult Students()
        {
            return View();
        }
        public PartialViewResult StudentsPartial()
        {
            var students = _studentService.GetAllActiveStudents();
            return PartialView("_Students", students);
        }

		public PartialViewResult InsertStudentPartial(int? studentId)
		{
            if(studentId == null || studentId > 0)
				return PartialView("_InsertStudentPartial");

			var student = _studentService.GetStudent((int)studentId);
			return PartialView("_InsertStudentPartial", student);
		}

        [HttpPost]
        public JsonResult InsertStudent(StudentDto studentDto)
        {
            if(studentDto != null)
            {
                if(studentDto.Id != 0)
					_studentService.UpdateStudent(studentDto);
				else
					_studentService.InsertStudent(studentDto);
			}

			return new JsonResult(new { Result = true, Message = "" });
        }

        [HttpPost]
		public JsonResult DeleteStudent(int studentId)
		{
			_studentService.DeleteStudent(studentId);
			return new JsonResult(new { Result = true, Message = "" });
		}

	}
}
