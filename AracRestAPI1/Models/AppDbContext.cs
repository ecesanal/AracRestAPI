using AracRestAPI1;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Arac_Tanimi> Arac_Tanimi { get; set; }
    public DbSet<Yakit_Girisi> Yakit_Girisi { get; set; }
    public DbSet<YillikRaporlama> YillikRaporlama { get; set; }
    public DbSet<AylikRaporlama> AylikRaporlama { get; set; }
}