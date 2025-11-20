namespace MyAgenda.API.Infrastructure.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AgendaDbContext _context;

    public ContactRepository(AgendaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
        => await _context.Contacts.AsNoTracking().ToListAsync();

    public async Task<Contact?> GetByIdAsync(int id)
        => await _context.Contacts.FindAsync(id);

    public async Task AddAsync(Contact contact)
        => await _context.Contacts.AddAsync(contact);

    public Task UpdateAsync(Contact contact)
    {
        _context.Contacts.Update(contact);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Contact contact)
    {
        _context.Contacts.Remove(contact);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
        => await _context.SaveChangesAsync();
}
