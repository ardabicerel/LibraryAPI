using Microsoft.EntityFrameworkCore;
using KutuphaneAPI.Models;

namespace KutuphaneAPI.Data
{
    public class KutuphaneContext : DbContext
    {
        public KutuphaneContext(DbContextOptions<KutuphaneContext> options) : base(options)
        {
        }

        public DbSet<Kitap> Kitaplar {get; set;}
    }
}