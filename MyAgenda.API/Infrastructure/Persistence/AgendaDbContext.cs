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

        // Seeding initial data
        modelBuilder.Entity<Contact>().HasData(
            new Contact { Id = 1, Name = "Ana Silva", Email = "ana.silva@example.com", Phone = "(11) 98876-1234", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 2, Name = "Bruno Santos", Email = "bruno.santos@example.com", Phone = "(21) 99745-6789", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 3, Name = "Carla Almeida", Email = "carla.almeida@example.com", Phone = "(31) 98432-5566", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 4, Name = "Diego Rodrigues", Email = "diego.rodrigues@example.com", Phone = "(41) 99123-7890", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 5, Name = "Elaine Costa", Email = "elaine.costa@example.com", Phone = "(51) 98765-4321", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 6, Name = "Fabio Mendes", Email = "fabio.mendes@example.com", Phone = "(71) 98123-4455", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 7, Name = "Gabriela Torres", Email = "gabriela.torres@example.com", Phone = "(81) 98654-7788", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 8, Name = "Henrique Lima", Email = "henrique.lima@example.com", Phone = "(91) 98321-0099", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 9, Name = "Isabela Martins", Email = "isabela.martins@example.com", Phone = "(62) 99234-5678", CreatedAt = DateTime.UtcNow },
            new Contact { Id = 10, Name = "João Pereira", Email = "joao.pereira@example.com", Phone = "(85) 99543-2211", CreatedAt = DateTime.UtcNow }
        );
    }

}
