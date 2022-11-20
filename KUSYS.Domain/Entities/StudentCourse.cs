using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Domain.Entities
{
	[Table("StudentCourses")]
	public class StudentCourse
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int StudentId { get; set; }

		[ForeignKey("StudentId")]
		public virtual Student Student { get; set; }

		public int CourseId { get; set; }

		[ForeignKey("CourseId")]
		public virtual Course Course { get; set; }
	}
}
