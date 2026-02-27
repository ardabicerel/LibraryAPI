using System.Text.Json.Serialization;

namespace KutuphaneAPI.Models
{
    public class Yazar
    {
        public int Id { get; set; }
        public string AdSoyad { get; set; } = string.Empty;

        // Bir yazarın birden fazla kitabı olabilir (Bire Çok İlişki)
        [JsonIgnore] // JSON çıktısında sonsuz döngüyü önlemek için bu etiketi kullanıyoruz
        public List<Kitap> Kitaplar { get; set; } = new List<Kitap>();
    }
}