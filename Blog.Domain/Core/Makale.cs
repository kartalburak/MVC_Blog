using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Core
{

    [Table("Makaleler")]
    public class Makale : EntityBase
    {

        public Makale()
        {
            this.Yorumlar = new List<Yorum>();
            this.Etiketler = new List<Etiket>();
        }


        [Required(ErrorMessage = "Lütfen Makale başlığını giriniz.")]
        [StringLength(50, ErrorMessage = "Başlık {0} karakterden uzun olmamalıdır!")]
        public string Baslik { get; set; }

        [Required(ErrorMessage = "Lütfen Makale içeriğini giriniz.")]
        [DataType(DataType.Html)]
        public string Icerik { get; set; }

        [StringLength(100)]
        public string Resim { get; set; }

        public int? UyeID { get; set; }      //BOŞ YOLLAMICAZ AMA KOYMADA FAYDA VAR .HATA FIRLATMAZ

        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Tarih Formatına uygun giriniz.")]
        public DateTime Tarih { get; set; }


        //İlişkiler

        public virtual Uye Uye { get; set; }

        public virtual List<Etiket> Etiketler { get; set; }

        public virtual List<Yorum> Yorumlar { get; set; }


    }
}
