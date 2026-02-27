using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Data;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarlarController : ControllerBase
    {
        private readonly KutuphaneContext _context;

        public YazarlarController(KutuphaneContext context)
        {
            _context = context;
        }

        // 1. TÜM YAZARLARI GETİR (GET /api/yazarlar)
        [HttpGet]
        public async Task<IActionResult> GetYazarlar()
        {
            var yazarlar = await _context.Yazarlar.ToListAsync();
            return Ok(yazarlar);
        }

        // 2. YENİ YAZAR EKLE (POST /api/yazarlar)
        [HttpPost]
        public async Task<IActionResult> YazarEkle(Yazar yeniYazar)
        {
            await _context.Yazarlar.AddAsync(yeniYazar);
            await _context.SaveChangesAsync();
            return Ok(yeniYazar);
        }
    }
}