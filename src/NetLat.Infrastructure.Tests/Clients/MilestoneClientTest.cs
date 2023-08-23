using Moq;
using NetLab.Domain.Clients.REST;
using NetLab.Domain.GitLab.Clients.Milestones;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.Responses;
using NetLab.Infrastructure.Clients.REST;
using NetLab.Infrastructure.GitLab.Wrappers.Http;
using NetLab.Infrastructure.Tests.Util;
using NetLab.Infrastructure.Wrappers.Http;

namespace NetLab.Infrastructure.Tests.Clients
{
    [TestFixture]
    public class MilestoneClientTest
    {
        private Mock<IPaginatedHttpClient> httpClientMock;
        private IMilestonesClient milestoneClient;

        [SetUp]
        public void SetUp()
        {
            this.httpClientMock = new Mock<IPaginatedHttpClient>();
            this.milestoneClient = new MilestoneClient(this.httpClientMock.Object);
        }

        [Test]
        public async Task CreateAsync_ShouldCreateMilestone()
        {
            // Arrange
            int projectId = 123;

            string url = URLs.GetMilestonesUrl(projectId, string.Empty);

            var response = new HttpResponse<string>
            {
                Content = "Milestone created successfully",
                IsSuccess = true
            };

            this.httpClientMock.Setup(client => client.PostAsync(It.Is<string>(s => s.Contains(url)),
                                                                 It.IsAny<NewMilestoneRequest>()))
                               .ReturnsAsync(response);

            // Act
            IResponse<string> result = await this.milestoneClient.CreateAsync(projectId, opt =>
            {
                opt.Descricao = "aaa";
                opt.Vencimento = DateTime.Today.AddDays(5);
                opt.Inicio = DateTime.Today;
                opt.Titulo = "Dog";
            });

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Content, Is.EqualTo("Milestone created successfully"));
            Assert.That(result.IsSuccess, Is.True);
        }

        [Test]
        public async Task GetAsync_ShouldRetrieveMilestones()
        {
            // Arrange
            int projectId = 123;
            string url = URLs.GetMilestonesUrl(projectId, string.Empty);

            PaginatedResponse<IList<Milestone>> page1 = new()
            {
                Content = new List<Milestone> { new Milestone() },
                IsSuccess = true
            };

            PaginatedResponse<IList<Milestone>> page2 = new()
            {
                Content = new List<Milestone> { new Milestone() },
                IsSuccess = true
            };

            List<PaginatedResponse<IList<Milestone>>> pages = new(2) { page1, page2 };

            this.httpClientMock.Setup(client => client.GetPagesAsync<Milestone>(It.Is<string>(s => s.Contains(url))))
                               .Returns(pages.ToAsyncEnumerable());

            // Act
            List<IResponse<IList<Milestone>>> milestones = new();
            await foreach (IResponse<IList<Milestone>> response in this.milestoneClient.GetAsync(projectId, _ => { }))
            {
                milestones.Add(response);
            }

            // Assert
            Assert.That(milestones, Has.Count.EqualTo(pages.Count));
        }

        // More test cases can be added to cover different scenarios:
        // - Test when response is not successful
        // - Test when options are configured differently
        // - Test when httpClient throws an exception
    }
}
