using Microsoft.AspNetCore.Mvc;
using Moq;
using MyAgenda.API.Application.DTOs;
using MyAgenda.API.Application.Services;
using MyAgenda.API.Controllers;

namespace MyAgenda.Tests.Controllers
{
    public class ContactsControllerTests
    {
        private readonly Mock<IContactService> _serviceMock;
        private readonly ContactsController _controller;

        public ContactsControllerTests()
        {
            _serviceMock = new Mock<IContactService>();
            _controller = new ContactsController(_serviceMock.Object);
        }

        // GET ALL
        [Fact]
        public async Task GetAll_ShouldReturnOkWithList()
        {
            var list = new List<ContactDto>
            {
                new ContactDto { Id = 1, Name = "John" }
            };

            _serviceMock.Setup(s => s.GetAllAsync())
                        .ReturnsAsync(list);

            var result = await _controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsAssignableFrom<IEnumerable<ContactDto>>(okResult.Value);

            Assert.Single(data);
        }

        // GET BY ID
        [Fact]
        public async Task GetById_ShouldReturnOk_WhenContactExists()
        {
            var dto = new ContactDto { Id = 10, Name = "Maria" };

            _serviceMock.Setup(s => s.GetByIdAsync(10))
                        .ReturnsAsync(dto);

            var result = await _controller.GetById(10);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<ContactDto>(okResult.Value);

            Assert.Equal(10, data.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenContactDoesNotExist()
        {
            _serviceMock.Setup(s => s.GetByIdAsync(999))
                        .ReturnsAsync((ContactDto?)null);

            var result = await _controller.GetById(999);

            Assert.IsType<NotFoundResult>(result);
        }

        // CREATE
        [Fact]
        public async Task Create_ShouldReturnOkWithCreatedContact()
        {
            var dto = new CreateContactDto
            {
                Name = "Test",
                Email = "x@y.com",
                Phone = "9999"
            };

            var created = new ContactDto
            {
                Id = 5,
                Name = "Test",
                Email = "x@y.com",
                Phone = "9999"
            };

            _serviceMock.Setup(s => s.CreateAsync(dto))
                        .ReturnsAsync(created);

            var result = await _controller.Create(dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<ContactDto>(okResult.Value);

            Assert.Equal(5, data.Id);
        }

        // UPDATE
        [Fact]
        public async Task Update_ShouldReturnOk_WhenUpdated()
        {
            var dto = new UpdateContactDto
            {
                Name = "Updated",
                Email = "u@y.com",
                Phone = "7777"
            };

            var updated = new ContactDto
            {
                Id = 3,
                Name = "Updated",
                Email = "u@y.com",
                Phone = "7777"
            };

            _serviceMock.Setup(s => s.UpdateAsync(3, dto))
                        .ReturnsAsync(updated);

            var result = await _controller.Update(3, dto);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<ContactDto>(okResult.Value);

            Assert.Equal("Updated", data.Name);
        }

        [Fact]
        public async Task Update_ShouldReturnNotFound_WhenContactDoesNotExist()
        {
            _serviceMock.Setup(s => s.UpdateAsync(100, It.IsAny<UpdateContactDto>()))
                        .ReturnsAsync((ContactDto?)null);

            var result = await _controller.Update(100, new UpdateContactDto());

            Assert.IsType<NotFoundResult>(result);
        }

        // DELETE
        [Fact]
        public async Task Delete_ShouldReturnNoContent_WhenDeleted()
        {
            _serviceMock.Setup(s => s.DeleteAsync(4))
                        .ReturnsAsync(true);

            var result = await _controller.Delete(4);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFound_WhenNotDeleted()
        {
            _serviceMock.Setup(s => s.DeleteAsync(7))
                        .ReturnsAsync(false);

            var result = await _controller.Delete(7);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
