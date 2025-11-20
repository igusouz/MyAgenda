namespace MyAgenda.API.Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;
    private readonly IMapper _mapper;

    public ContactService(IContactRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ContactDto>> GetAllAsync()
    {
        var contacts = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ContactDto>>(contacts);
    }

    public async Task<ContactDto?> GetByIdAsync(int id)
    {
        var contact = await _repository.GetByIdAsync(id);
        return contact == null ? null : _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto> CreateAsync(CreateContactDto dto)
    {
        var contact = _mapper.Map<Contact>(dto);
        await _repository.AddAsync(contact);
        await _repository.SaveChangesAsync();
        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<ContactDto?> UpdateAsync(int id, UpdateContactDto dto)
    {
        var contact = await _repository.GetByIdAsync(id);
        if (contact == null) return null;

        _mapper.Map(dto, contact);
        await _repository.UpdateAsync(contact);
        await _repository.SaveChangesAsync();

        return _mapper.Map<ContactDto>(contact);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _repository.GetByIdAsync(id);
        if (contact == null) return false;

        await _repository.DeleteAsync(contact);
        await _repository.SaveChangesAsync();
        return true;
    }
}
