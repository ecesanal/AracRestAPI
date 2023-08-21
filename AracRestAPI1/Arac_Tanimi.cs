using System.ComponentModel.DataAnnotations;

namespace AracRestAPI1
{
    public class Arac_Tanimi
    {
        [Key]
        public int arac_id { get; set; }
        public string arac_plaka { get; set; }
        public string arac_aciklama { get; set; }
        public string arac_yakit_turu { get; set; }

    }
}
