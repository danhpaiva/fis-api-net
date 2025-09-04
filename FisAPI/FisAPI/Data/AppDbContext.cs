using FisAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FisAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public DbSet<EventoDeSurf> EVENTOS { get; set; } = null!;
    public DbSet<Onda> ONDAS { get; set; } = null!;
    public DbSet<Praia> PRAIAS { get; set; } = null!;
    public DbSet<Surfista> SURFISTAS { get; set; } = null!;
}
