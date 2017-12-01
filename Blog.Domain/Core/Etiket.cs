using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Core
{
    public class Etiket : EntityBase
    {
        public Etiket()
        {
            this.Makaleler = new List<Makale>();
        }


        [Required(ErrorMessage = "Lütfen etiket içeriğini giriniz.")]
        [StringLength(30, ErrorMessage = "İçerik {0} karakterden uzun olmamalıdır!")]
        public string Icerik { get; set; }

        public virtual List<Makale> Makaleler { get; set; } //çoka çok ilişki var(etiket-makale)



    }
}
