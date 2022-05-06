using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Net;
using System.Threading.Tasks;
using TicTac.WebAPI.Middleware;
using Xunit;

namespace TicTac.Tests
{
    public class ExceptionHandlingMiddlewareTests
    {
		[Fact]
		public async Task ExceptionHandlingMiddlewareTest_Returns500StatusCode()
		{
			// Arrange
			var expectedException = new ArgumentNullException();
			RequestDelegate mockNextMiddleware = (HttpContext) =>
			{
				return Task.FromException(expectedException);
			};
			var httpContext = new DefaultHttpContext();
			var logger = Mock.Of<ILogger<ExceptionHandlingMiddleware>>();

			var exceptionHandlingMiddleware = new ExceptionHandlingMiddleware(mockNextMiddleware);

			// Act
			await exceptionHandlingMiddleware.Invoke(httpContext, logger);

			// Assert
			Assert.Equal(HttpStatusCode.InternalServerError, (HttpStatusCode)httpContext.Response.StatusCode);
		}
	}
}
