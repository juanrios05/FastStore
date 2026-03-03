using FastStore.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FastStore.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Producto> Productos => Set<Producto>();
    public DbSet<OrdenReposicion> OrdenesReposicion => Set<OrdenReposicion>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Producto>()
            .Property(p => p.Precio)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<OrdenReposicion>()
            .Property(o => o.Estado)
            .HasMaxLength(20);
    }
}