using KUSYS.Core.Dto;
using System;

namespace KUSYS.Core.Implementations
{
    public interface IUserService
    {
		/// <summary>
		/// It is a method of insert users. 
		/// </summary>
		void InsertUser(UserDto dto);

		/// <summary>
		/// It is a method of get user.
		/// </summary>
		/// <param name="userName">Username of the requested user</param>
		/// <returns> Returns UserDto if matching username is found. Returns null if not found </returns>
		UserDto GetUser(string userName);


    }
}
