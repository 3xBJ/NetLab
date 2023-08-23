using Moq;
using NetLab.Domain.GitLab.Clients;
using NetLab.Infrastructure.Clients;

namespace NetLab.Infrastructure.Tests.Clients
{
    [TestFixture]
    public class ClientFactoryTest
    {
        [Test]
        public void ResolveREST_ShouldReturnGitLabClient()
        {
            // Arrange
            Mock<HttpClient> httpClientMock = new();
            string gitlabUri = "http://example.com/gitlab";
            string gitlabToken = "your-private-token";

            //Act
            IGitLabClient gitLabClient = ClientFactory.ResolveREST(httpClientMock.Object, gitlabUri, gitlabToken);

            //Assert
            Assert.That(gitLabClient, Is.Not.Null);
            Assert.That(gitLabClient.Issue, Is.Not.Null);
            Assert.That(gitLabClient.Labels, Is.Not.Null);
            Assert.That(gitLabClient.Milestone, Is.Not.Null);
            Assert.That(gitLabClient.MergeRequest, Is.Not.Null);
        }

        [Test]
        public void ResolveREST_ShouldSetHeader()
        {
            // Arrange
            using HttpClient httpClient = new();
            string gitlabUri = "http://example.com/gitlab";
            string gitlabToken = "your-private-token";

            //Act
            IGitLabClient gitLabClient = ClientFactory.ResolveREST(httpClient, gitlabUri, gitlabToken);

            //Assert
            string? values = httpClient.DefaultRequestHeaders
                                       .GetValues("private-token")
                                       .FirstOrDefault();

            Assert.That(values, Is.EqualTo(gitlabToken));
        }
    }
}
