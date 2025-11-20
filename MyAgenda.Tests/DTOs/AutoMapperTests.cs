using AutoMapper;
using MyAgenda.API.Application.DTOs;
using MyAgenda.API.Application.Mappings;
using MyAgenda.API.Domain.Entities;

namespace MyAgenda.Tests.DTOs
{
    public class AutoMapperTests
    {
        private readonly IMapper _mapper;

        public AutoMapperTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ContactProfile());
            });

            _mapper = config.CreateMapper();
        }

        [Fact]
        public void Should_Map_CreateContactDto_To_Contact()
        {
            var dto = new CreateContactDto
            {
                Name = "Test",
                Email = "x@y.com",
                Phone = "123"
            };

            var entity = _mapper.Map<Contact>(dto);

            Assert.Equal(dto.Name, entity.Name);
            Assert.Equal(dto.Email, entity.Email);
            Assert.Equal(dto.Phone, entity.Phone);
        }

        [Fact]
        public void Should_Map_Contact_To_ContactDto()
        {
            var contact = new Contact
            {
                Id = 1,
                Name = "Test",
                Email = "x@y.com",
                Phone = "123"
            };

            var dto = _mapper.Map<ContactDto>(contact);

            Assert.Equal(contact.Id, dto.Id);
            Assert.Equal(contact.Name, dto.Name);
        }
    }
}
