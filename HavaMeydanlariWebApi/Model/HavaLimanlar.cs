using System.ComponentModel.DataAnnotations;

namespace HavaMeydanlariWebApi.Model
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
