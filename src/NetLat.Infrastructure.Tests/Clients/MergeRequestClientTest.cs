using Moq;
using NetLab.Domain.Clients.REST;
using NetLab.Domain.GitLab.Clients.MergeRequests;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Clients.REST;
using NetLab.Infrastructure.GitLab.Wrappers.Http;
using NetLab.Infrastructure.Wrappers.Http;
using NetLab.Modelos.Entidades.GitLab;

namespace NetLab.Infrastructure.Tests.Clients
{
    [TestFixture]
    public class MergeRequestClientTests
    {
        private Mock<IPaginatedHttpClient> httpClientMock;
        private IMergeRequestClient mergeRequestClient;

        [SetUp]
        public void SetUp()
        {
            this.httpClientMock = new Mock<IPaginatedHttpClient>();
            this.mergeRequestClient = new MergeRequestClient(httpClientMock.Object);
        }

        [Test]
        public async Task GetAsync_ShouldRetrieveMergeRequests()
        {
            // Arrange
            int projectId = 123;
            string uri = URLs.GetMergeRequestUrl(projectId, string.Empty);

            this.httpClientMock.Setup(client => client.GetPagesAsync<MergeRequest>(It.Is<string>(s => s.Contains(uri))))
                               .Returns(GetMrsAsync());

            // Act
            List<IResponse<IList<MergeRequest>>> mergeRequests = new();
            await foreach (IResponse<IList<MergeRequest>> resp in mergeRequestClient.GetAsync(projectId, _ => { }))
            {
                mergeRequests.Add(resp);
            }

            // Assert
            Assert.That(mergeRequests, Has.Count.EqualTo(2));
        }

        [Test]
        public async Task GetAsyncWithIssue_ShouldRetrieveMergeRequests()
        {
            // Arrange
            int projectId = 123;
            int issueId = 456;

            string uri = URLs.GetRelatedMRUrl(projectId, issueId, string.Empty);

            this.httpClientMock.Setup(client => client.GetPagesAsync<MergeRequest>(It.Is<string>(s => s.Contains(uri))))
                               .Returns(GetMrsAsync());

            // Act
            List<IResponse<IList<MergeRequest>>> mergeRequests = new();
            await foreach (IResponse<IList<MergeRequest>> resp in mergeRequestClient.GetAsync(projectId, issueId, _ => { }))
            {
                mergeRequests.Add(resp);
            }

            // Assert
            Assert.That(mergeRequests, Has.Count.EqualTo(2));
        }

        // More test cases can be added to cover different scenarios:
        // - Test when response is not successful
        // - Test when options are configured differently
        // - Test when httpClient throws an exception


        private async static IAsyncEnumerable<PaginatedResponse<IList<MergeRequest>>> GetMrsAsync()
        {
            yield return new PaginatedResponse<IList<MergeRequest>>
            {
                Content = new List<MergeRequest> { new MergeRequest() },
                IsSuccess = true
            };

            yield return new PaginatedResponse<IList<MergeRequest>>
            {
                Content = new List<MergeRequest> { new MergeRequest() },
                IsSuccess = true
            };

            await Task.CompletedTask;
        }
    }
}
