namespace MyAgenda.API.Application.Mappings;

public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateContactDto, Contact>();
        CreateMap<UpdateContactDto, Contact>();
    }
}
