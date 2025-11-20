using MyAgenda.API.Application.DTOs;

namespace MyAgenda.Tests.DTOs
{
    public class ContactDtoTests
    {
        [Fact]
        public void Should_Create_DTO()
        {
            var dto = new ContactDto
            {
                Id = 1,
                Name = "Test",
                Email = "t@test.com",
                Phone = "123"
            };

            Assert.Equal(1, dto.Id);
            Assert.Equal("Test", dto.Name);
        }
    }
}
