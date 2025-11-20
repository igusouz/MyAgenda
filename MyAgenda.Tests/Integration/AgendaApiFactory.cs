using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAgenda.API; // <--- CORREÇÃO: Usando o namespace da sua API
using MyAgenda.API.Infrastructure.Persistence;

namespace MyAgenda.Tests.Integration
{
    // O tipo genérico 'Program' agora se refere ao 'Program' de MyAgenda.API
    public class AgendaApiFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove DB real (Sqlite, no seu caso)
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<AgendaDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                // Adiciona DB In-Memory para testes
                services.AddDbContext<AgendaDbContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTestsDb");
                });

                // É uma boa prática garantir que o provedor de serviços seja construído
                // e que o banco de dados in-memory seja criado, se necessário.
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AgendaDbContext>();

                    // Garante que o banco de dados In-Memory seja criado.
                    db.Database.EnsureCreated();
                    // Aqui você pode adicionar seeds (dados iniciais) para seus testes, se necessário.
                }
            });
        }
    }
}