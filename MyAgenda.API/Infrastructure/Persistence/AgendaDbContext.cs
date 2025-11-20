using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Domain.Entities; // caso a entidade Contact esteja aqui

namespace MyAgenda.API.Infrastructure.Persistence;

public class AgendaDbContext : DbContext
{
    public AgendaDbContext(DbContextOptions<AgendaDbContext> options) : base(options) { }

    public DbSet<Contact> Contacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(b =>
        {
            b.HasKey(x => x.Id);

            b.Property(x => x.Id)
             .ValueGeneratedOnAdd();

            b.Property(x => x.Name)
             .IsRequired()
             .HasMaxLength(100);

            b.Property(x => x.Email)
             .IsRequired()
             .HasMaxLength(150);

            b.Property(x => x.Phone)
             .IsRequired()
             .HasMaxLength(30);

            b.Property(x => x.CreatedAt)
             .HasDefaultValueSql("datetime('now')");
        });
    }

}
