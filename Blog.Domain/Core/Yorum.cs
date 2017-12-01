using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Core
{
    public class Yorum : EntityBase
    {
       

        [Required(ErrorMessage = "Lütfen Yorum içeriğini giriniz.")]
        public string Icerik { get; set; }

        public int? UyeID { get; set; }

        public int MakaleID { get; set; }  //Başka yerde olmayacağı için ? kaldırılabilir.

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Tarih Formatına uygun giriniz.")]
        public DateTime Tarih { get; set; }

        //ilişkiler

        public virtual Uye Uye { get; set; }

        public virtual Makale Makale { get; set; }


    }
}
