using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HavaMeydanlariWebApi.Model
{
    public class Ucaklar
    {
        [Key]
        public int UcakId { get; set; }
        
        public string UcakRengi { get; set; }
        public string UcakTipi { get; set; }

        [Range(0,350,ErrorMessage ="0 ile 350 arasında değer girin")]
        public int YolcuKapasitesi { get; set; }
        public int UcakGenislik { get; set; }
        public decimal BiletFiyati { get; set; }

        public int FirmaId { get; set; }
        [ForeignKey("FirmaId")]
        public Firmalar Firmalar { get; set; }








    }
}
