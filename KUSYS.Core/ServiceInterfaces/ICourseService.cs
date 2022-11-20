using KUSYS.Core.Dto;

namespace KUSYS.Core.Implementations
{
    public interface ICourseService
    {
		/// <summary>
		/// Method that returns the list of courses that the student is enrolled in.
		/// </summary>
		List<CourseDto> GetStudentCourses(int studentId);

		/// <summary>
		/// Method that returns the list of courses that the student is not registered for
		/// </summary>
		List<CourseDto> GetSelectableCourses(int studentId);

		/// <summary>
		/// The method used to enroll the student in a new course
		/// </summary>
		void AddSelectableCourse(int studentId, int courseId);

		/// <summary>
		/// Method used to remove a registered course from a student
		/// </summary>
		void RemoveSelectedCourse(int studentId, int courseId);
    }
}
