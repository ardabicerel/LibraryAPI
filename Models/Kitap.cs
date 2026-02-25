namespace KutuphaneAPI.Models
{
    public class Kitap
    {
        public int Id {get; set;}

        public string KitapAdi {get; set;} = string.Empty;

        public string Yazar {get; set;} = string.Empty; 

        public int YayinYili {get; set;}
    }
}