using System;
using System.ComponentModel.DataAnnotations;

namespace AracRestAPI1
{
    public class AylikRaporlama
    {
        [Key]
        public int yakit_arac { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public decimal ToplamYakitAlimi { get; set; }
        public decimal OrtalamaTuketim { get; set; }
    }
}
