using AracRestAPI1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AracRestAPI1.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class AracController : ControllerBase
    {

        private readonly AppDbContext _context;

        public AracController(AppDbContext context)
        {
            _context = context;
        }

        // Tüm araçları getir
        [HttpGet]
        public ActionResult<IEnumerable<Arac_Tanimi>> GetAraclar()
        {
            return _context.Arac_Tanimi.ToList();
        }

       

            // Bir aracı getir
        [HttpGet("{id}")]
        public ActionResult<Arac_Tanimi> GetArac(int id)
        {
            var arac = _context.Arac_Tanimi.Find(id);

            if (arac == null)
                return NotFound();

            return arac;
        }

        

        // Yeni arac ekle
        [HttpPost]
        public ActionResult<Arac_Tanimi> PostArac(Arac_Tanimi arac)
        {
            _context.Arac_Tanimi.Add(arac);
            _context.SaveChanges();
            return null;
        }
       


        // Bir aracı güncelle
        [HttpPut("{id}")]
        public IActionResult PutArac(int id, Arac_Tanimi arac)
      
        {
            if (id != arac.arac_id)
                return BadRequest();

            _context.Entry(arac).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }


        // Bir aracı sil
        [HttpDelete("{id}")]
        public IActionResult DeleteArac(int id)
        {
            var arac = _context.Arac_Tanimi.Find(id);

            if (arac == null)
                return NotFound();

            _context.Arac_Tanimi.Remove(arac);
            _context.SaveChanges();

            return NoContent();
        }
        
    }
    [Route("api/[controller]")]
    [ApiController]
    public class YakitGirisiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public YakitGirisiController(AppDbContext context)
        {
            _context = context;
        }

        //Tüm yakitlari getir
        [HttpGet]
        public ActionResult<IEnumerable<Yakit_Girisi>> GetYakit()
        {
            return _context.Yakit_Girisi.ToList();
        }

        // Bir Yakit getir
        [HttpGet("{id}")]
        public ActionResult<Yakit_Girisi> GetYakit(int id)
        {
            var yakit = _context.Yakit_Girisi.Find(id);

            if (yakit == null)
                return NotFound();

            return yakit;
        }

        // Yeni yakit ekle
        [HttpPost]
        public ActionResult<Yakit_Girisi> PostArac(Yakit_Girisi yakit)
        {
            _context.Yakit_Girisi.Add(yakit);
            _context.SaveChanges();
            return null;
        }

        // Bir yakiti güncelle
        [HttpPut("{id}")]
        public IActionResult PutYakit(int id, Yakit_Girisi yakit)

        {
            if (id != yakit.yakit_id)
                return BadRequest();

            _context.Entry(yakit).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // Bir yakiti sil
        [HttpDelete("{id}")]
        public IActionResult DeleteYakit(int id)
        {
            var yakit = _context.Yakit_Girisi.Find(id);

            if (yakit == null)
                return NotFound();

            _context.Yakit_Girisi.Remove(yakit);
            _context.SaveChanges();

            return NoContent();

        }

    }

    

}
