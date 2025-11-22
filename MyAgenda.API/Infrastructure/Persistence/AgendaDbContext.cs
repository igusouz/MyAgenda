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
             .HasMaxLength(11);

            b.Property(x => x.CreatedAt)
             .HasDefaultValueSql("datetime('now')");
        });

        // Seeding initial data
        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "Ana Silva", Email = "ana.silva@example.com", Phone = "11988761234", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 2, Name = "Bruno Santos", Email = "bruno.santos@example.com", Phone = "21997456789", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 3, Name = "Carla Almeida", Email = "carla.almeida@example.com", Phone = "31984325566", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 4, Name = "Diego Rodrigues", Email = "diego.rodrigues@example.com", Phone = "41991237890", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 5, Name = "Elaine Costa", Email = "elaine.costa@example.com", Phone = "51987654321", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 6, Name = "Fabio Mendes", Email = "fabio.mendes@example.com", Phone = "71981234455", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 7, Name = "Gabriela Torres", Email = "gabriela.torres@example.com", Phone = "81986547788", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 8, Name = "Henrique Lima", Email = "henrique.lima@example.com", Phone = "91983210099", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 9, Name = "Isabela Martins", Email = "isabela.martins@example.com", Phone = "62992345678", CreatedAt = DateTime.Parse("2025-01-01") },
            new Contact { Id = 10, Name = "João Pereira", Email = "joao.pereira@example.com", Phone = "85995432211", CreatedAt = DateTime.Parse("2025-01-01") }
        );
    }

}
