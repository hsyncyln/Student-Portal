using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace KUSYS.Web.Models
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(maximumLength:50)]
        [Display(Name = "Kullanıcı Adı")]
        [DataType(DataType.Text, ErrorMessage = "Kullanıcı adınızı giriniz.")]
        public string UserName { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(20)]
        [Display(Name = "Parola")]
        [DataType(DataType.Password, ErrorMessage = "Parolanızı giriniz.")]
        public string Password { get; set; }

    }
}
