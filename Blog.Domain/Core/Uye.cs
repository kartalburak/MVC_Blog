using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Core
{
    public class Uye:EntityBase
    {

        public Uye()
        {
            this.Makaleler = new List<Makale>();
            this.Yorumlar = new List<Yorum>();
        }


        [Required(ErrorMessage = "Lütfen üye adını giriniz.")]
        [StringLength(30, ErrorMessage = "İsim {0} karakterden uzun olmamalıdır!")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen üye soyadını giriniz.")]
        [StringLength(30, ErrorMessage = "Soyisim {0} karakterden uzun olmamalıdır!")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Lütfen Email adresinizi giriniz.")]
        [EmailAddress(ErrorMessage = "Email formatına uygun giriniz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz.")]
        [DataType(DataType.Password)]                               //şifre gözükmesin diye
        public string Sifre { get; set; }


        [NotMapped]       //property modelde kullanılabilir ancak sql de kolon oluşturmaz
        [Compare("Sifre", ErrorMessage = "Şifreler aynı değil!")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]     //kolon ismi verme
        public string SifreTekrar { get; set; }


        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Tarih Formatına uygun giriniz.")]
        public DateTime Tarih { get; set; }


        //ilişkiler

        public virtual List<Makale> Makaleler { get; set; }

        public virtual List<Yorum> Yorumlar { get; set; }

    }
}
