using System.ComponentModel.DataAnnotations;

namespace HavaLimaniMVCprojesi.Models
{
    public class HavaLimanlar
    {
        [Key]
        public int HavaLimaniId { get; set; }

        public string Yerleskesi { get; set; }
        public decimal Maliyeti { get; set; }

        public int YolcuKapasitesi { get; set; }

        public int PistSayisi { get; set; }
     


    }
}
