namespace MyAgenda.API.Infrastructure.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task AddAsync(Contact contact);
    Task UpdateAsync(Contact contact);
    Task DeleteAsync(Contact contact);
    Task SaveChangesAsync();
}
