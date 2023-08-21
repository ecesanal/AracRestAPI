using System.ComponentModel.DataAnnotations;

namespace AracRestAPI1
{
    public class YillikRaporlama
    {
        [Key]
        public int yakit_arac { get; set; }
        public int Yil { get; set; }
        public decimal OrtalamaTuketim { get; set; }
    }
    
}
