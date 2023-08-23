using Moq;
using NetLab.Domain.Clients.REST;
using NetLab.Domain.GitLab.Clients.Issues;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.GitLab.Wrappers.Http;
using NetLab.Infrastructure.Tests.Util;
using NetLab.Infrastructure.Wrappers.Http;
using NetLab.Infrastructure.Wrappers.Http.Interfaces;
using NetLab.Modelos.Entidades.GitLab;

namespace NetLab.Infrastructure.Tests.Clients
{
    [TestFixture]
    public class IssueClientTests
    {
        private Mock<IPaginatedHttpClient> httpClientMock;
        private IIssueClient issueClient;

        [SetUp]
        public void Setup()
        {
            this.httpClientMock = new Mock<IPaginatedHttpClient>();
            this.issueClient = new IssueClient(httpClientMock.Object);
        }

        [Test]
        public async Task GetAsync_ReturnsListOfIssues()
        {
            // Arrange
            int projectId = 123;
            List<Issue> issues = new() { new Issue(), new Issue() };
            PaginatedResponse<IList<Issue>> page1 = new()
            { 
                Content = issues,
                IsSuccess = true
            };

            PaginatedResponse<IList<Issue>> page2 = new()
            {
                Content = issues,
                IsSuccess = true
            };

            IEnumerable<PaginatedResponse<IList<Issue>>> pages = new List<PaginatedResponse<IList<Issue>>>(2) { page1, page2 };

            this.httpClientMock.Setup(client => client.GetPagesAsync<Issue>(It.IsAny<string>()))
                               .Returns(pages.ToAsyncEnumerable());

            // Act
            List<IResponse<IList<Issue>>> result = new();
            await foreach (IResponse<IList<Issue>> responseItem in this.issueClient.GetAsync(projectId, _ => { }))
            {
                result.Add(responseItem);
            }

            // Assert
            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result[0], Is.EqualTo(page1));
            Assert.That(result[0].Content, Is.EqualTo(issues));
            Assert.That(result[0].IsSuccess, Is.True);
            Assert.That(result[1], Is.EqualTo(page2));
        }

        [Test]
        public async Task GetStatisticsAsync_ReturnsIssueStatistics()
        {
            // Arrange
            int projectId = 123;
            IssueStatistics statistics = new();
            IHttpResponse<IssueStatistics> response = new HttpResponse<IssueStatistics>()
            {
                Content = statistics,
                IsSuccess= true
            };

            this.httpClientMock.Setup(client => client.GetAsync<IssueStatistics>(It.IsAny<string>()))
                               .Returns(Task.FromResult(response));

            // Act
            IResponse<IssueStatistics> result = await issueClient.GetStatisticsAsync(projectId, _ => { });

            // Assert
            Assert.That(result.Content, Is.EqualTo(statistics));
            Assert.That(result.IsSuccess, Is.True);
        }
    }
}