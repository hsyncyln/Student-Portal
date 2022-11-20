using KUSYS.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Core.Implementations
{
    public interface IStudentService
    {
        /// <summary>
        /// Insert Student Method
        /// </summary>
        void InsertStudent(StudentDto dto);

		/// <summary>
		/// Update Student Method
		/// </summary>
		void UpdateStudent(StudentDto dto);

		/// <summary>
		/// Delete Student Method
		/// </summary>
		void DeleteStudent(int studentId);

		/// <summary>
		/// Method that returns all active students information
		/// </summary>
		List<StudentDto> GetAllActiveStudents();

		/// <summary>
		/// The method that returns the requested student information
		/// </summary>
		StudentDto GetStudent(int studentId);
    }
}
