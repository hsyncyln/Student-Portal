using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Domain.Entities
{
	[Table("Courses")]
	public class Course: EntityBase
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public virtual ICollection<StudentCourse> CourseStudents { get; set; }

	}
}
