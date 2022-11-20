using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KUSYS.Domain.Entities;

namespace KUSYS.Domain
{
    public class EntityBase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//Insert Bilgileri
		public DateTime InsertDate { get; set; }
		public int InsertUserId { get; set; }
		
		[ForeignKey("InsertUserId")]
		public User InsertUser { get; set; }


		//Update Bilgileri
		public DateTime? UpdateDate { get; set; }
		public int? UpdateUserId { get; set; }
		public User UpdateUser { get; set; }

		public bool IsDeleted { get; set; }

	}
}
