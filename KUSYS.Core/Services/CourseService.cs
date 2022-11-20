using KUSYS.Core.Dto;
using KUSYS.Core.Implementations;
using KUSYS.Core.Services.Base;
using KUSYS.Domain.DBContext;
using KUSYS.Domain.Entities;

namespace KUSYS.Core.Services
{
    public class CourseService : ServiceBase, ICourseService
    {
        public CourseService(KUSYSDbContext db) : base(db) { }

        public List<CourseDto> GetStudentCourses(int studentId)
        {
            var courses = KUSYSDB.StudentCourses.Where(x => x.StudentId == studentId && !x.Course.IsDeleted)
                .Select(x =>  new CourseDto()
                {
                    Id= x.CourseId,
                    Code= x.Course.Code,
                    Name= x.Course.Name,
                }).ToList();

            return courses;
        }
		public List<CourseDto> GetSelectableCourses(int studentId)
		{

			var selectedCourseIds = KUSYSDB.StudentCourses.Where(x => x.StudentId == studentId && !x.Course.IsDeleted)
				.Select(x => x.CourseId).ToList();

			var courses = KUSYSDB.Courses.Where(x => !x.IsDeleted && !selectedCourseIds.Contains(x.Id))
				.Select(x => new CourseDto()
				{
					Id = x.Id,
					Code = x.Code,
					Name = x.Name,
				}).ToList();

			return courses;
		}

		public void AddSelectableCourse(int studentId, int courseId)
		{
			var studentCourse = KUSYSDB.StudentCourses.Where(x => x.StudentId == studentId && x.CourseId == courseId).FirstOrDefault();

			if (studentCourse == null)
			{
				studentCourse = new StudentCourse() { StudentId= studentId, CourseId = courseId };
				KUSYSDB.StudentCourses.Add(studentCourse);
				KUSYSDB.SaveChanges();
			}

		}

		public void RemoveSelectedCourse(int studentId, int courseId)
		{
			var studentCourse = KUSYSDB.StudentCourses.Where(x => x.StudentId == studentId && x.CourseId == courseId).FirstOrDefault();

			if (studentCourse != null)
			{
				KUSYSDB.StudentCourses.Remove(studentCourse);
				KUSYSDB.SaveChanges();
			}
		}
	}
}
