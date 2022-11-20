using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Core.Dto
{
	public class StudentDto
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }

		//public StudentDto(int id, string firstName, string lastName, DateTime birthDate)
		//{
		//	Id = id;
		//	FirstName = firstName;
		//	LastName = lastName;
		//	BirthDate = birthDate;
		//}
	}
}
