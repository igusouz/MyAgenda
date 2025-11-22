using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyAgenda.API;
using MyAgenda.API.Infrastructure.Persistence;

namespace MyAgenda.Tests.Integration
{
    public class AgendaApiFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<AgendaDbContext>));

                if (descriptor != null)
                    services.Remove(descriptor);

                services.AddDbContext<AgendaDbContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTestsDb");
                });

                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<AgendaDbContext>();

                    db.Database.EnsureCreated();
                }
            });
        }
    }
}