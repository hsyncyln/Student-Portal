using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KUSYS.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[StringLength(50)]
        public string UserName { get; set; }
        public int UserTypeId { get; set; }

        public User(string userName, int userTypeId)
        {
            UserName = userName;
            UserTypeId = userTypeId;
        }
        public User() { }
    }
}