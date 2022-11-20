using KUSYS.Core.Dto;
using KUSYS.Core.Implementations;
using KUSYS.Core.Services.Base;
using KUSYS.Domain.DBContext;
using KUSYS.Domain.Entities;


namespace KUSYS.Core.Services
{
    public class StudentService : ServiceBase, IStudentService
    {
        public StudentService(KUSYSDbContext db) : base(db) { }

        public void InsertStudent(StudentDto dto)
        {
            var entity = ConvertToStudent(dto);
            KUSYSDB.Students.Add(entity);
            KUSYSDB.SaveChanges();
        }
        public void UpdateStudent(StudentDto dto)
        {
            var student = KUSYSDB.Students.FirstOrDefault(x=> x.Id == dto.Id);
            if (student != null)
            {
                student.FirstName = dto.FirstName;
                student.LastName = dto.LastName;
                student.BirthDate = dto.BirthDate;
				KUSYSDB.SaveChanges();
			}
			//Öğrenci yok
        }

        public void DeleteStudent(int studentId)
        {
            var student = KUSYSDB.Students.FirstOrDefault(x => x.Id == studentId);
            if (student != null)
            {
                KUSYSDB.Students.Remove(student);
                KUSYSDB.SaveChanges();
            }
            //Öğrenci yok
        }
		public List<StudentDto> GetAllActiveStudents()
        {
            var models = KUSYSDB.Students.Where(x=> !x.IsDeleted)
                .Select(x => /*ConvertToStudentDto(x)*/
                new StudentDto()
                {
                    Id = x.Id, 
                    FirstName= x.FirstName,
                    LastName= x.LastName,
                    BirthDate= x.BirthDate,
                }).ToList();

            return models;
        }
		public StudentDto GetStudent(int studentId)
		{
            var model = KUSYSDB.Students.Where(x => !x.IsDeleted && x.Id == studentId)
				.Select(x => ConvertToStudentDto(x)).FirstOrDefault();

			return model;
		}

		private Student ConvertToStudent(StudentDto dto)
        {
            var entity = new Student();
            entity.FirstName = dto.FirstName;
            entity.LastName = dto.LastName;
            entity.BirthDate = dto.BirthDate;

            return entity;
        }

		private StudentDto ConvertToStudentDto(Student entity)
		{
			var dto = new StudentDto();
			dto.FirstName = entity.FirstName;
			dto.LastName = entity.LastName;
			dto.BirthDate = entity.BirthDate;

			return dto;
		}

	}
}
