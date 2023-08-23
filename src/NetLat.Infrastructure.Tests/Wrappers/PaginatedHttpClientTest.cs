using Moq;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.GitLab.Wrappers.Http;
using NetLab.Infrastructure.Wrappers.Http;
using NetLab.Infrastructure.Wrappers.Http.Interfaces;
using System.Net;
using System.Net.Http.Headers;

namespace NetLab.Infrastructure.Tests.Wrappers
{
    [TestFixture]
    public class PaginatedHttpClientTest
    {
        private Mock<IHttpClient> httpClientMock;
        private IPaginatedHttpClient paginatedHttpClient;

        [SetUp]
        public void SetUp()
        {
            this.httpClientMock = new Mock<IHttpClient>();
            this.paginatedHttpClient = new PaginatedHttpClient(this.httpClientMock.Object);
        }

        [Test]
        public async Task GetPagesAsync_ShouldRetrieveAllPages()
        {
            // Arrange
            Mock<IHttpResponse<IList<int>>> response1 = new();

            HttpResponse<IList<int>> response2 = new()
            {
                Content = new List<int> { 4, 5, 6 },
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            };

            response1.SetupGet(x => x.Content).Returns(new List<int> { 1, 2, 3 });
            response1.SetupGet(x => x.StatusCode).Returns(HttpStatusCode.OK);
            response1.SetupGet(x => x.IsSuccess).Returns(true);
            response1.Setup(x => x.GetHeader<int>(It.IsAny<string>())).Returns(2);

            this.httpClientMock.SetupSequence(client => client.GetAsync<IList<int>>(It.IsAny<string>()))
                               .ReturnsAsync(response1.Object)
                               .ReturnsAsync(response2);

            // Act
            await using IAsyncEnumerator<PaginatedResponse<IList<int>>> enumerator = this.paginatedHttpClient.GetPagesAsync<int>("some_url")
                                                                                                             .GetAsyncEnumerator();

            List<PaginatedResponse<IList<int>>> responses = new();
            while (await enumerator.MoveNextAsync())
            {
                responses.Add(enumerator.Current);
            }

            // Assert
            Assert.That(responses, Has.Count.EqualTo(2));
            Assert.That(responses[0].Content, Is.Not.Null);
            Assert.That(responses[0].Content, Has.Count.EqualTo(3));
            Assert.That(responses[1].Content, Is.Not.Null);
            Assert.That(responses[1].Content[2], Is.EqualTo(6));
            Assert.That(responses[0].NextPage, Is.EqualTo(2));
            Assert.That(responses[0].TotalPages, Is.EqualTo(2));
        }

        [Test]
        public async Task GetPagesAsync_ShouldRetrieveSinglePage()
        {
            // Arrange
            HttpResponse<IList<int>> response = new()
            {
                Content = new List<int> { 1, 2, 3 },
                StatusCode = HttpStatusCode.OK,
                IsSuccess = true
            };

            this.httpClientMock.Setup(client => client.GetAsync<IList<int>>(It.IsAny<string>()))
                               .ReturnsAsync(response);

            // Act
            await using IAsyncEnumerator<PaginatedResponse<IList<int>>> enumerator = this.paginatedHttpClient.GetPagesAsync<int>("some_url")
                                                                                                             .GetAsyncEnumerator();

            _ = await enumerator.MoveNextAsync();
            bool hasMorePages = await enumerator.MoveNextAsync();

            // Assert
            Assert.That(hasMorePages, Is.False);
        }

        //criar caso para com header com mais itens






        //// More test cases can be added to cover various scenarios, edge cases, and exception handling.

        //[Test]
        //public async Task GetPageAsync_ShouldRetrieveSinglePage()
        //{
        //    // Arrange
        //    var response = new HttpResponse<IList<int>>
        //    {
        //        Content = new List<int> { 1, 2, 3 },
        //        StatusCode = HttpStatusCode.OK,
        //        IsSuccess = true
        //    };
        //    _httpClientMock.Setup(client => client.GetAsync<IList<int>>(It.IsAny<string>()))
        //                  .ReturnsAsync(response);

        //    // Act
        //    var paginatedResponse = await _paginatedHttpClient.GetPageAsync<int>("some_url");

        //    // Assert
        //    Assert.AreEqual(HttpStatusCode.OK, paginatedResponse.StatusCode);
        //    Assert.IsTrue(paginatedResponse.IsSuccess);
        //    Assert.AreEqual(3, paginatedResponse.Content.Count);
        //    // More assertions for other properties can be added.
        //}

        //// More test cases can be added to cover the remaining methods, properties, and scenarios.

        //[Test]
        //public void SetPageParam_ShouldAppendPageParamToUrl()
        //{
        //    // Arrange
        //    string originalUrl = "http://example.com/api/data";
        //    int page = 2;

        //    // Act
        //    string newUrl = PaginatedHttpClient.SetPageParam(originalUrl, page);

        //    // Assert
        //    Assert.AreEqual("http://example.com/api/data?per_page=100&page=2", newUrl);
        //}
    }
}
