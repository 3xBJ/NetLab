using Moq;
using NetLab.Domain.Clients.REST;
using NetLab.Domain.GitLab.Clients.Labels;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Clients.REST;
using NetLab.Infrastructure.GitLab.Wrappers.Http;
using NetLab.Infrastructure.Tests.Util;

namespace NetLab.Infrastructure.Tests.Clients
{
    [TestFixture]
    public class LabelClientTest
    {
        private Mock<IPaginatedHttpClient> httpClientMock;
        private ILabelClient labelClient;

        [SetUp]
        public void SetUp()
        {
            this.httpClientMock = new Mock<IPaginatedHttpClient>();
            this.labelClient = new LabelClient(httpClientMock.Object);
        }

        [Test]
        public async Task GetAsync_ShouldRetrieveLabels()
        {
            // Arrange
            int projectId = 123;
            string url = URLs.GetLabelsUrl(projectId, string.Empty);

            PaginatedResponse<IList<Label>> page1 = new()
            {
                Content = new List<Label> { new Label() },
                IsSuccess = true
            };

            PaginatedResponse<IList<Label>> page2 = new()
            {
                Content = new List<Label> { new Label(), new Label() },
                IsSuccess = true
            };

            List<PaginatedResponse<IList<Label>>> pages = new(2) { page1, page2 };

            this.httpClientMock.Setup(client => client.GetPagesAsync<Label>(It.Is<string>(s => s.Contains(url))))
                               .Returns(pages.ToAsyncEnumerable());

            // Act
            List<IResponse<IList<Label>>> labels = new();
            await foreach (IResponse<IList<Label>> response in this.labelClient.GetAsync(projectId, _ => { }))
            {
                labels.Add(response);
            }

            // Assert
            Assert.That(labels, Has.Count.EqualTo(2));
            Assert.That(labels[0].Content, Is.Not.Null);
            Assert.That(labels[0].Content, Has.Count.EqualTo(1));
            Assert.That(labels[0].IsSuccess, Is.True);
            Assert.That(labels[1].Content, Is.Not.Null);
            Assert.That(labels[1].Content, Has.Count.EqualTo(2));
            Assert.That(labels[1].IsSuccess, Is.True);
        }

        // Additional test cases can be added to cover different scenarios:
        // - Test when response is not successful
        // - Test when options are configured differently
        // - Test when httpClient throws an exception
    }
}
