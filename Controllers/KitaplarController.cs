using Microsoft.AspNetCore.Mvc;
using KutuphaneAPI.Data;
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
        public IActionResult GetKitaplar()
        {
            var kitaplar = _context.Kitaplar.ToList();
            return Ok(kitaplar); // 200 OK durum kodu ile JSON olarak döndürür.
        }

        [HttpGet("arama")]
        public IActionResult KitapAra([FromQuery] string yazar)
        {
            // Eğer yazar parametresi boş gönderildiyse 400 Bad Request döndür
            if (string.IsNullOrWhiteSpace(yazar))
            {
                return BadRequest("Lütfen aramak için bir yazar adı girin.");
            }

            // Veritabanında yazar adını içeren kitapları filtrele
            var bulunanKitaplar = _context.Kitaplar
                .Where(k => k.Yazar.Contains(yazar))
                .ToList();

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
        public IActionResult PostKitap(Kitap kitap)
        {
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges(); // Değişiklikleri fiziksel veri tabanına işler.
            return Ok(kitap);
        }

        // 3. KİTAP SİLME (DELETE)
        [HttpDelete("{id}")]
        public IActionResult DeleteKitap(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null)
            {
                return NotFound(); // Eğer o ID'ye ait kitap yoksa 404 Not Found döndürür.
            }

            _context.Kitaplar.Remove(kitap);
            _context.SaveChanges();
            return NoContent(); // Başarıyla silindiğinde 204 No Content döndürür.
        }

        [HttpDelete("hepsini-sil")]
        public IActionResult TumKitaplariSil()
        {
            // Veritabanındaki tüm kitapları çekiyoruz
            var tumKitaplar = _context.Kitaplar.ToList();

            // Eğer tablo zaten boşsa işlem yapmaya gerek yok
            if (tumKitaplar.Count == 0)
            {
                return NotFound("Veritabanında silinecek kitap bulunmamaktadır.");
            }

            // Entity Framework'ün RemoveRange metodu ile listeyi topluca siliyoruz
            _context.Kitaplar.RemoveRange(tumKitaplar);
            
            // Değişiklikleri veritabanına kaydediyoruz
            _context.SaveChanges();

            // Başarılı işlem sonucu 204 döndürüyoruz
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult PutKitap(int id, Kitap guncelKitap)
        {
            // Önce güncellenmek istenen kitabı veritabanında buluyoruz
            var mevcutKitap = _context.Kitaplar.Find(id);
            if (mevcutKitap == null)
            {
                return NotFound(); // Kitap yoksa 404 döndürür
            }

            // Yeni gelen verileri, mevcut kitabın üzerine yazıyoruz
            mevcutKitap.KitapAdi = guncelKitap.KitapAdi;
            mevcutKitap.Yazar = guncelKitap.Yazar;
            mevcutKitap.YayinYili = guncelKitap.YayinYili;

            // Değişiklikleri fiziksel veritabanına kaydediyoruz
            _context.SaveChanges();
            return NoContent(); // Başarılı işlem sonrası 204 döndürür
        }
    }
}