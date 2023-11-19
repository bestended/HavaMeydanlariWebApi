using System.ComponentModel.DataAnnotations;

namespace HavaLimaniMVCprojesi.Models
{
    public class Firmalar
    {
        [Key]
        public int FirmaId { get; set; }
        public string FirmaAdi { get; set; }
        public decimal FirmaBütcesi { get; set; }
        public string FirmaMerkezi { get; set; }
        public string FirmaTelefon { get; set; }





    }
}
