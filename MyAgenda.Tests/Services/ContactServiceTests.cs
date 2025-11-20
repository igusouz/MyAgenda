using AutoMapper;
using Moq;
using MyAgenda.API.Application.DTOs;
using MyAgenda.API.Application.Services;
using MyAgenda.API.Domain.Entities;
using MyAgenda.API.Infrastructure.Repositories;

namespace MyAgenda.Tests.Services
{
    public class ContactServiceTests
    {
        private readonly ContactService _service;
        private readonly Mock<IContactRepository> _repositoryMock;
        private readonly IMapper _mapper;

        public ContactServiceTests()
        {
            _repositoryMock = new Mock<IContactRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contact, ContactDto>();
                cfg.CreateMap<CreateContactDto, Contact>();
                cfg.CreateMap<UpdateContactDto, Contact>();
            });

            _mapper = config.CreateMapper();

            _service = new ContactService(_repositoryMock.Object, _mapper);
        }

        // CREATE
        [Fact]
        public async Task CreateAsync_ShouldCreateContact()
        {
            var dto = new CreateContactDto
            {
                Name = "Test",
                Email = "x@y.com",
                Phone = "9999"
            };

            _repositoryMock
                .Setup(x => x.AddAsync(It.IsAny<Contact>()))
                .Callback<Contact>(c => c.Id = 1)
                .Returns(Task.CompletedTask);

            var result = await _service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(1, result.Id);
        }

        // GET BY ID
        [Fact]
        public async Task GetByIdAsync_ShouldReturnContact_WhenExists()
        {
            var contact = new Contact { Id = 10, Name = "Maria", Email = "m@m.com", Phone = "1234" };

            _repositoryMock
                .Setup(x => x.GetByIdAsync(10))
                .ReturnsAsync(contact);

            var result = await _service.GetByIdAsync(10);

            Assert.NotNull(result);
            Assert.Equal(10, result.Id);
            Assert.Equal("Maria", result.Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenNotFound()
        {
            _repositoryMock
                .Setup(x => x.GetByIdAsync(99))
                .ReturnsAsync((Contact?)null);

            var result = await _service.GetByIdAsync(99);

            Assert.Null(result);
        }

        // GET ALL
        [Fact]
        public async Task GetAllAsync_ShouldReturnAllContacts()
        {
            var contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "A" },
                new Contact { Id = 2, Name = "B" }
            };

            _repositoryMock
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(contacts);

            var result = await _service.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        // UPDATE
        [Fact]
        public async Task UpdateAsync_ShouldUpdateContact_WhenExists()
        {
            var contact = new Contact { Id = 5, Name = "Original" };

            var dto = new UpdateContactDto
            {
                Name = "Updated",
                Email = "new@mail.com",
                Phone = "7777"
            };

            _repositoryMock
                .Setup(x => x.GetByIdAsync(5))
                .ReturnsAsync(contact);

            _repositoryMock
                .Setup(x => x.UpdateAsync(contact))
                .Returns(Task.CompletedTask);

            var result = await _service.UpdateAsync(5, dto);

            Assert.NotNull(result);
            Assert.Equal("Updated", result.Name);
        }

        [Fact]
        public async Task UpdateAsync_ShouldReturnNull_WhenContactDoesNotExist()
        {
            _repositoryMock
                .Setup(x => x.GetByIdAsync(999))
                .ReturnsAsync((Contact?)null);

            var dto = new UpdateContactDto { Name = "X" };

            var result = await _service.UpdateAsync(999, dto);

            Assert.Null(result);
        }


        // DELETE
        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenDeleted()
        {
            var contact = new Contact { Id = 3 };

            _repositoryMock
                .Setup(x => x.GetByIdAsync(3))
                .ReturnsAsync(contact);

            _repositoryMock
                .Setup(x => x.DeleteAsync(contact))
                .Returns(Task.CompletedTask);

            var result = await _service.DeleteAsync(3);

            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnFalse_WhenNotFound()
        {
            _repositoryMock
                .Setup(x => x.GetByIdAsync(50))
                .ReturnsAsync((Contact?)null);

            var result = await _service.DeleteAsync(50);

            Assert.False(result);
        }
    }
}