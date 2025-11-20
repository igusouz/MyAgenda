using System.Net;
using System.Net.Http.Json;
using MyAgenda.API.Application.DTOs;

namespace MyAgenda.Tests.Integration
{
    public class ContactsIntegrationTests : IClassFixture<AgendaApiFactory>
    {
        private readonly HttpClient _client;

        public ContactsIntegrationTests(AgendaApiFactory factory)
        {
            _client = factory.CreateClient();
        }

        // CREATE
        [Fact]
        public async Task CreateContact_ShouldReturnOk_AndPersistData()
        {
            var dto = new CreateContactDto
            {
                Name = "Integration Test",
                Email = "test@x.com",
                Phone = "9999-9999"
            };

            var response = await _client.PostAsJsonAsync("/api/contacts", dto);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<ContactDto>();

            Assert.NotNull(result);
            Assert.Equal(dto.Name, result!.Name);
        }

        // GET ALL
        [Fact]
        public async Task GetAll_ShouldReturnList()
        {
            var response = await _client.GetAsync("/api/contacts");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var list = await response.Content.ReadFromJsonAsync<List<ContactDto>>();

            Assert.NotNull(list);
            Assert.IsType<List<ContactDto>>(list);
        }

        // GET BY ID
        [Fact]
        public async Task GetById_ShouldReturnOk_WhenContactExists()
        {
            var create = await _client.PostAsJsonAsync("/api/contacts",
                new CreateContactDto
                {
                    Name = "TestOne",
                    Email = "x@x.com",
                    Phone = "12345"
                });

            var created = await create.Content.ReadFromJsonAsync<ContactDto>();

            var response = await _client.GetAsync($"/api/contacts/{created!.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var result = await response.Content.ReadFromJsonAsync<ContactDto>();

            Assert.NotNull(result);
            Assert.Equal(created.Id, result!.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnNotFound_WhenContactDoesNotExist()
        {
            var response = await _client.GetAsync("/api/contacts/999999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // UPDATE
        [Fact]
        public async Task UpdateContact_ShouldReturnOk_WhenContactExists()
        {
            var create = await _client.PostAsJsonAsync("/api/contacts",
                new CreateContactDto { Name = "Old", Email = "old@x.com", Phone = "0000" });

            var created = await create.Content.ReadFromJsonAsync<ContactDto>();

            var updateDto = new UpdateContactDto
            {
                Name = "New",
                Email = "new@x.com",
                Phone = "1111"
            };

            var response = await _client.PutAsJsonAsync($"/api/contacts/{created!.Id}", updateDto);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var updated = await response.Content.ReadFromJsonAsync<ContactDto>();

            Assert.NotNull(updated);
            Assert.Equal(updateDto.Name, updated!.Name);
        }

        [Fact]
        public async Task UpdateContact_ShouldReturnNotFound_WhenContactDoesNotExist()
        {
            var dto = new UpdateContactDto
            {
                Name = "Test",
                Email = "t@t.com",
                Phone = "123"
            };

            var response = await _client.PutAsJsonAsync("/api/contacts/1000", dto);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // DELETE
        [Fact]
        public async Task DeleteContact_ShouldReturnNoContent_WhenSuccess()
        {
            var create = await _client.PostAsJsonAsync("/api/contacts",
                new CreateContactDto { Name = "ToDelete", Email = "d@x.com", Phone = "999" });

            var created = await create.Content.ReadFromJsonAsync<ContactDto>();

            var response = await _client.DeleteAsync($"/api/contacts/{created!.Id}");

            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Fact]
        public async Task DeleteContact_ShouldReturnNotFound_WhenIdDoesNotExist()
        {
            var response = await _client.DeleteAsync("/api/contacts/999999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
