using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Core.Dto
{
	public enum UserType
	{
		Admin = 1,
		Student = 2
	}
	public class UserDto
	{
		public int Id { get; set; }
		public string UserName { get; set; }
		public UserType UserType { get; set; }

		public UserDto(int id, string userName, UserType userType)
		{
			Id = id;
			UserName = userName;
			UserType = userType;
		}

		public UserDto(int id, string userName, int userTypeId)
		{
			Id = id;
			UserName = userName;

			var typeName = Enum.GetName(typeof(UserType), userTypeId);
			if(typeName != null)
				UserType = (UserType)Enum.Parse(typeof(UserType), typeName, true); 
		}
	}
}
