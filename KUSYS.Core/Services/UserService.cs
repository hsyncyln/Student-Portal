using KUSYS.Core.Dto;
using KUSYS.Core.Implementations;
using KUSYS.Core.Services.Base;
using KUSYS.Domain.DBContext;
using KUSYS.Domain.Entities;

namespace KUSYS.Core.Services
{
    public class UserService : ServiceBase, IUserService
    {
        public UserService(KUSYSDbContext db) : base(db) { }

		
		public void InsertUser(UserDto dto)
        {
            var oldUser = KUSYSDB.Users.FirstOrDefault(x => x.UserName == dto.UserName);

            if (oldUser != null)
            {
                var entity = ConvertToUser(dto);
                KUSYSDB.Users.Add(entity);
                KUSYSDB.SaveChanges();
            }
        }
		
		public UserDto GetUser(string userName)
        {
            var user = KUSYSDB.Users.FirstOrDefault(x => x.UserName == userName);
            if (user != null)
            {
                var dto = ConvertToUserDto(user);
                if (dto != null)
                {
                    //SetResult(ServiceResultType.Success);
                    return dto;
                }
                //SetResult(ServiceResultType.Fail, null, "Beklenmedik bir hata oluştu.");
            }
            //SetResult(ServiceResultType.Fail, null, "Kullanıcı adı veya şifreniz hatalıdır.");
            return null;
        }

        /// <summary>
        /// Convert User dto to User entity method
        /// </summary>
        /// <returns>User entity instance</returns>
        private User ConvertToUser(UserDto dto) => new User(dto.UserName, (int)dto.UserType);

		/// <summary>
		/// Convert User entity to User dto method
		/// </summary>
		/// <returns>User dto instance</returns>
		private UserDto ConvertToUserDto(User user) => new UserDto(user.Id, user.UserName, user.UserTypeId);
    }
}