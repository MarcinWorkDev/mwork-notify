using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using MWork.Common.WebApi.Middleware;
using Xunit;
using Xunit.Abstractions;

namespace MWork.Common.WebApi.Tests
{
    public class ErrorHandlingMiddlewareTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ErrorHandlingMiddlewareTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async Task Invoke_Next_Success()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Response.StatusCode = 200;
            
            var requestDelegateMock = new Mock<RequestDelegate>();
            requestDelegateMock
                .Setup(x => x.Invoke(httpContext));
            
            var errorHandlingMid = new ErrorHandlingMiddleware(NullLogger<ErrorHandlingMiddleware>.Instance);
            await errorHandlingMid.InvokeAsync(httpContext, requestDelegateMock.Object);

            Assert.Equal(200, httpContext.Response.StatusCode);
        }
        
        [Fact]
        public async Task Invoke_Next_Exception_Without_Status_Code_Returns_Default()
        {
            var httpContext = new DefaultHttpContext();
            
            var requestDelegateMock = new Mock<RequestDelegate>();
            requestDelegateMock
                .Setup(x => x.Invoke(httpContext))
                .Throws(new Exception());
            
            var errorHandlingMid = new ErrorHandlingMiddleware(NullLogger<ErrorHandlingMiddleware>.Instance);
            await errorHandlingMid.InvokeAsync(httpContext, requestDelegateMock.Object);

            Assert.Equal(ErrorHandlingMiddleware.DefaultErrorStatusCode, httpContext.Response.StatusCode);
        }
        
        [Fact]
        public async Task Invoke_Next_Exception_With_Status_Code_Returns_Provided()
        {
            var httpContext = new DefaultHttpContext();
            var exception = new Exception();
            exception.Data.Add("HttpResponseSetStatus", (int)HttpStatusCode.NotFound);
            
            var requestDelegateMock = new Mock<RequestDelegate>();
            requestDelegateMock
                .Setup(x => x.Invoke(httpContext))
                .Throws(exception);
            
            var errorHandlingMid = new ErrorHandlingMiddleware(NullLogger<ErrorHandlingMiddleware>.Instance);
            await errorHandlingMid.InvokeAsync(httpContext, requestDelegateMock.Object);

            Assert.Equal((int)HttpStatusCode.NotFound, httpContext.Response.StatusCode);
        }
        
        [Fact]
        public async Task Invoke_Next_Exception_With_Invalid_Status_Code_Returns_Defult()
        {
            var httpContext = new DefaultHttpContext();
            var exception = new Exception();
            exception.Data.Add("HttpResponseSetStatus", int.MaxValue);
            
            var requestDelegateMock = new Mock<RequestDelegate>();
            requestDelegateMock
                .Setup(x => x.Invoke(httpContext))
                .Throws(exception);
            
            var errorHandlingMid = new ErrorHandlingMiddleware(NullLogger<ErrorHandlingMiddleware>.Instance);
            await errorHandlingMid.InvokeAsync(httpContext, requestDelegateMock.Object);

            Assert.Equal(ErrorHandlingMiddleware.DefaultErrorStatusCode, httpContext.Response.StatusCode);
        }
        
        [Fact]
        public async Task Invoke_Next_Exception_With_Invalid_Type_Of_Status_Code_Returns_Default()
        {
            var httpContext = new DefaultHttpContext();
            var exception = new Exception();
            exception.Data.Add("HttpResponseSetStatus", "invalid");
            
            var requestDelegateMock = new Mock<RequestDelegate>();
            requestDelegateMock
                .Setup(x => x.Invoke(httpContext))
                .Throws(exception);
            
            var errorHandlingMid = new ErrorHandlingMiddleware(NullLogger<ErrorHandlingMiddleware>.Instance);
            await errorHandlingMid.InvokeAsync(httpContext, requestDelegateMock.Object);

            Assert.Equal(ErrorHandlingMiddleware.DefaultErrorStatusCode, httpContext.Response.StatusCode);
        }
    }
}