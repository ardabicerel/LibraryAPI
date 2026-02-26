using Microsoft.AspNetCore.Mvc;
using KutuphaneAPI.Data;
using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Controllers
{
    // Gelen isteklerin "api/kitaplar" URL'si üzerinden bu sınıfa yönlendirilmesini sağlar.
    [Route("api/[controller]")]
    [ApiController]
    public class KitaplarController : ControllerBase
    {
        private readonly KutuphaneContext _context;

        // Dependency Injection (Bağımlılık Enjeksiyonu) ile veri tabanı bağlantısını sınıfa dahil ediyoruz.
        public KitaplarController(KutuphaneContext context)
        {
            _context = context;
        }

        // 1. KİTAPLARI LİSTELEME (GET)
        [HttpGet]
        public async Task<IActionResult> GetKitaplar()
        {
            var kitaplar = await _context.Kitaplar.ToListAsync();
            return Ok(kitaplar); // 200 OK durum kodu ile JSON olarak döndürür.
        }

        [HttpGet("arama")]
        public async Task<IActionResult> KitapAra([FromQuery] string yazar)
        {
            // Eğer yazar parametresi boş gönderildiyse 400 Bad Request döndür
            if (string.IsNullOrWhiteSpace(yazar))
            {
                return BadRequest("Lütfen aramak için bir yazar adı girin.");
            }

            // Veritabanında yazar adını içeren kitapları filtrele
            var bulunanKitaplar = await _context.Kitaplar
                .Where(k => k.Yazar.Contains(yazar))
                .ToListAsync();

            // Eğer kritere uyan kitap bulunamadıysa 404 Not Found döndür
            if (bulunanKitaplar.Count == 0)
            {
                return NotFound("Bu yazara ait kitap bulunamadı.");
            }

            // Bulunan kitapları 200 OK ile JSON olarak döndür
            return Ok(bulunanKitaplar);
        }

        // 2. YENİ KİTAP EKLEME (POST)
        [HttpPost]
        public async Task<IActionResult> PostKitap(Kitap kitap)
        {
            await _context.Kitaplar.AddAsync(kitap);
            await _context.SaveChangesAsync(); // Değişiklikleri fiziksel veri tabanına işler.
            return Ok(kitap);
        }

        // 3. KİTAP SİLME (DELETE)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKitap(int id)
        {
            var kitap = await _context.Kitaplar.FindAsync(id);
            if (kitap == null)
            {
                return NotFound(); // Eğer o ID'ye ait kitap yoksa 404 Not Found döndürür.
            }

            _context.Kitaplar.Remove(kitap);
            await _context.SaveChangesAsync();
            return NoContent(); // Başarıyla silindiğinde 204 No Content döndürür.
        }

        [HttpDelete("hepsini-sil")]
        public async Task<IActionResult> TumKitaplariSil()
        {
            // Veritabanındaki tüm kitapları çekiyoruz
            var tumKitaplar = await _context.Kitaplar.ToListAsync();

            // Eğer tablo zaten boşsa işlem yapmaya gerek yok
            if (tumKitaplar.Count == 0)
            {
                return NotFound("Veritabanında silinecek kitap bulunmamaktadır.");
            }

            // Entity Framework'ün RemoveRange metodu ile listeyi topluca siliyoruz
            _context.Kitaplar.RemoveRange(tumKitaplar);
            
            // Değişiklikleri veritabanına kaydediyoruz
            await _context.SaveChangesAsync();

            // Başarılı işlem sonucu 204 döndürüyoruz
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKitap(int id, Kitap guncelKitap)
        {
            // Önce güncellenmek istenen kitabı veritabanında buluyoruz
            var mevcutKitap = await _context.Kitaplar.FindAsync(id);
            if (mevcutKitap == null)
            {
                return NotFound(); // Kitap yoksa 404 döndürür
            }

            // Yeni gelen verileri, mevcut kitabın üzerine yazıyoruz
            mevcutKitap.KitapAdi = guncelKitap.KitapAdi;
            mevcutKitap.Yazar = guncelKitap.Yazar;
            mevcutKitap.YayinYili = guncelKitap.YayinYili;

            // Değişiklikleri fiziksel veritabanına kaydediyoruz
            await _context.SaveChangesAsync();
            return NoContent(); // Başarılı işlem sonrası 204 döndürür
        }
    }
}