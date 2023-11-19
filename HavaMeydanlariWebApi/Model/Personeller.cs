using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HavaMeydanlariWebApi.Model
{
    public class Personeller
    {
        [Key]
        public int PersonelId { get; set; }

        public string PersonelAdi { get; set; }
        public string PersonelSoyadi { get; set; }

        [Range(18,65,ErrorMessage ="18-65 yas arası deger girin ")]
        public int Yas { get; set; }
        public DateTime CalismaTarih { get; set; }

        public bool Vardiya { get; set; }

        public int UcakId { get; set; }
        [ForeignKey("UcakId")]
        public Ucaklar Ucaklar { get; set; }

       
        public int HavaLimaniId { get; set; }
        [ForeignKey("HavaLimaniId")]

        public HavaLimanlar HavaLimanlar { get; set; }


    }
}
