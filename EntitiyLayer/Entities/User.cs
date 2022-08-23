using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiyLayer.Entities
{
    public class User
    {
        //database üzerinde tutulacak olan verilerin field'larının tanımlanması
        public int Id { get; set; }

        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        public string Surname { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil")]
        public string RePassword { get; set; }

        [Display(Name = "Mail")]
        [DataType(DataType.EmailAddress)]
        public string Mail { get; set; }

    }
}
