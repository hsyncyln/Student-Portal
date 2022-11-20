using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Domain.Entities
{
	[Table("Students")]
	public class Student : EntityBase
    {
		//[Key]
		//[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		//public int Id { get; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

		public int UserId { get; set; }

		[ForeignKey("UserId")]
		public virtual User User { get; set; }

		public virtual ICollection<StudentCourse> StudentCourses { get; set; }

	}
}
