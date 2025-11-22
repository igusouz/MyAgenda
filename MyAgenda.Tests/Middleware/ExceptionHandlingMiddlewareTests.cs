using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using MyAgenda.API.Middleware;

namespace MyAgenda.Tests.Middleware
{
    public class ExceptionMiddlewareTests
    {
        [Fact]
        public async Task Middleware_ShouldReturn500_WhenExceptionIsThrown()
        {
            var loggerMock = new Mock<ILogger<ExceptionMiddleware>>();

            var next = new RequestDelegate(_ => throw new Exception("Test exception"));
            var middleware = new ExceptionMiddleware(next, loggerMock.Object);

            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            await middleware.InvokeAsync(context);

            Assert.Equal(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
            Assert.Equal("application/json", context.Response.ContentType);

            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var json = await new StreamReader(context.Response.Body).ReadToEndAsync();

            Assert.Contains("\"title\":\"Internal server error\"", json);
            Assert.Contains("\"detail\":\"Test exception\"", json);

            loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((obj, _) => obj.ToString()!.Contains("unexpected error")),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()
                ),
                Times.Once
            );
        }
    }
}