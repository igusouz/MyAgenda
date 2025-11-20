using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Infrastructure.Persistence;

public static class DbContextInMemoryFactory
{
    public static AgendaDbContext Create()
    {
        var options = new DbContextOptionsBuilder<AgendaDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        return new AgendaDbContext(options);
    }
}