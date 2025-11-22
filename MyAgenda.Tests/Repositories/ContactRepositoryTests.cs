using MyAgenda.API.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MyAgenda.API.Domain.Entities;

namespace MyAgenda.Tests.Repositories
{
    public class ContactRepositoryTests
    {
        [Fact]
        public async Task AddAsync_Should_Add_Contact_To_Context()
        {
            var context = DbContextInMemoryFactory.Create();
            var repository = new ContactRepository(context);

            var contact = new Contact
            {
                Name = "Carlos Silva",
                Email = "carlos@test.com",
                Phone = "123456789"
            };

            await repository.AddAsync(contact);
            await repository.SaveChangesAsync();

            Assert.Equal(1, await context.Contacts.CountAsync());
        }

        [Fact]
        public async Task GetAllAsync_Should_Return_All_Contacts()
        {
            var context = DbContextInMemoryFactory.Create();
            var repository = new ContactRepository(context);

            context.Contacts.Add(new Contact { Name = "A", Email = "a@test.com", Phone = "111" });
            context.Contacts.Add(new Contact { Name = "B", Email = "b@test.com", Phone = "222" });
            await context.SaveChangesAsync();

            var result = await repository.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Contact_When_Exists()
        {
            var context = DbContextInMemoryFactory.Create();
            var repository = new ContactRepository(context);

            var contact = new Contact { Name = "Ana", Email = "ana@test.com", Phone = "111" };
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();

            var result = await repository.GetByIdAsync(contact.Id);

            Assert.NotNull(result);
            Assert.Equal("Ana", result!.Name);
        }

        [Fact]
        public async Task GetByIdAsync_Should_Return_Null_When_Not_Exists()
        {
            var context = DbContextInMemoryFactory.Create();
            var repository = new ContactRepository(context);

            var result = await repository.GetByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Entity()
        {
            var context = DbContextInMemoryFactory.Create();
            var repository = new ContactRepository(context);

            var contact = new Contact { Name = "Old", Email = "old@test.com", Phone = "000" };
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();

            contact.Name = "Updated";

            await repository.UpdateAsync(contact);
            await repository.SaveChangesAsync();

            var updated = await context.Contacts.FindAsync(contact.Id);

            Assert.Equal("Updated", updated!.Name);
        }

        [Fact]
        public async Task DeleteAsync_Should_Remove_Entity()
        {
            var context = DbContextInMemoryFactory.Create();
            var repository = new ContactRepository(context);

            var contact = new Contact { Name = "To Delete", Email = "delete@test.com", Phone = "999" };
            context.Contacts.Add(contact);
            await context.SaveChangesAsync();

            await repository.DeleteAsync(contact);
            await repository.SaveChangesAsync();

            Assert.Empty(context.Contacts);
        }
    }
}
