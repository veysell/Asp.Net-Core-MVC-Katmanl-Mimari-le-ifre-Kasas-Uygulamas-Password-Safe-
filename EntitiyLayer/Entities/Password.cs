using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Entities
{
    public class Password
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Site Adı/Adresi")]
        public string WebSiteName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Kullanıcı Adı")]
        public string SiteUserName { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string SitePassword { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Compare("SitePassword", ErrorMessage = "Şifreler aynı değil")]
        public string ReSitePassword { get; set; }

        public int UserId { get; set; }

    }
}
