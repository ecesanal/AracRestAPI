using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using AracRestAPI1.Models;
using System.Collections.Generic;

namespace AracRestAPI1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AylikRaporController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AylikRaporController(AppDbContext context)
        {
            _context = context;
        }

        // AYLIK RAPORLAMA API metotları

        [HttpGet("{yakit_arac}/{yil}/{ay}")]
        public async Task<ActionResult<IEnumerable<AylikRaporlama>>> GetAylikYakitRapor(int yakit_arac, int yil, int ay)
        {
            var aylikYakitAlimRaporu = await _context.Yakit_Girisi
                .Where(yg => yg.yakit_arac == yakit_arac && yg.yakit_zamani.Year == yil && yg.yakit_zamani.Month == ay)
                .GroupBy(yg => yg.yakit_arac)
                .Select(g => new AylikRaporlama
                {
                    yakit_arac = g.Key,
                    BaslangicTarihi = new DateTime(yil, ay, 1),
                    BitisTarihi = new DateTime(yil, ay, DateTime.DaysInMonth(yil, ay)),
                    ToplamYakitAlimi = g.Sum(y => y.yakit_miktari),
                     OrtalamaTuketim = g.Sum(y => y.yakit_miktari) / g.Sum(y => y.yakit_km) //yakıt tüketimini kilometre başına hesaplama
                })
                .ToListAsync();

            if (aylikYakitAlimRaporu == null)
            {
                return NotFound();
            }

            return aylikYakitAlimRaporu;
        }
    }
    // YILLIK RAPORLAMA API metotları

    [Route("api/[controller]")]
    [ApiController]
    public class YillikRaporController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YillikRaporController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("{yakit_arac}/{yil}")]
        public async Task<ActionResult<YillikRaporlama>> GetYillikRapor(int yakit_arac, int yil)
        {
            var yillikRapor = await _context.Yakit_Girisi
                .Where(yg => yg.yakit_arac == yakit_arac && yg.yakit_zamani.Year == yil)
                .GroupBy(yg => yg.yakit_arac)
                .Select(g => new YillikRaporlama
                {
                    yakit_arac = g.Key,
                    Yil = yil,
                    OrtalamaTuketim = g.Sum(y => y.yakit_miktari) / g.Sum(y => y.yakit_km) //yakıt tüketimini kilometre başına hesaplama
                })
                .FirstOrDefaultAsync();

            if (yillikRapor == null)
            {
                return NotFound();
            }

            return yillikRapor;
        }



    }
}
