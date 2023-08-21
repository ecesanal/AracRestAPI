using System.ComponentModel.DataAnnotations;

namespace AracRestAPI1
{
    public class Yakit_Girisi
    {
        [Key]
        public int yakit_id { get; set; }
        public System.DateTime yakit_zamani { get; set; }
        public int yakit_arac { get; set; }
        public int yakit_km { get; set; }
        public decimal yakit_miktari { get; set; }
        public decimal yakit_ucret { get; set; }
    }
}
