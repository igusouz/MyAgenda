namespace MyAgenda.API.Application.Services;

public interface IContactService
{
    Task<IEnumerable<ContactDto>> GetAllAsync();
    Task<ContactDto?> GetByIdAsync(int id);
    Task<ContactDto> CreateAsync(CreateContactDto dto);
    Task<ContactDto?> UpdateAsync(int id, UpdateContactDto dto);
    Task<bool> DeleteAsync(int id);
}
