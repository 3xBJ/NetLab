using Moq;
using NetLab.Domain.GitLab.Clients;
using NetLab.Domain.GitLab.Clients.Issues;
using NetLab.Domain.GitLab.Clients.Labels;
using NetLab.Domain.GitLab.Clients.MergeRequests;
using NetLab.Domain.GitLab.Clients.Milestones;
using NetLab.GitLab;

namespace NetLab.Infrastructure.Tests.Clients
{
    [TestFixture]
    public class GitLabClientTest
    {
        private Mock<IIssueClient> issueClientMock;
        private Mock<IMergeRequestClient> mergeRequestClientMock;
        private Mock<IMilestonesClient> milestonesClientMock;
        private Mock<ILabelClient> labelClientMock;
        private IGitLabClient gitLabClient;

        [SetUp]
        public void SetUp()
        {
            this.issueClientMock = new Mock<IIssueClient>();
            this.mergeRequestClientMock = new Mock<IMergeRequestClient>();
            this.milestonesClientMock = new Mock<IMilestonesClient>();
            this.labelClientMock = new Mock<ILabelClient>();

            this.gitLabClient = new GitLabClient(
                issueClientMock.Object,
                mergeRequestClientMock.Object,
                milestonesClientMock.Object,
                labelClientMock.Object
            );
        }

        [Test]
        public void Constructor_ShouldInitializeClients()
        {
            // Assert
            Assert.That(gitLabClient.Issue, Is.Not.Null);
            Assert.That(gitLabClient.MergeRequest, Is.Not.Null);
            Assert.That(gitLabClient.Milestone, Is.Not.Null);
            Assert.That(gitLabClient.Labels, Is.Not.Null);
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenIssueClientIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GitLabClient(null!, mergeRequestClientMock.Object, milestonesClientMock.Object, labelClientMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenMRClientIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GitLabClient(issueClientMock.Object, null!, milestonesClientMock.Object, labelClientMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenMilestoneClientIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GitLabClient(issueClientMock.Object, mergeRequestClientMock.Object, null!, labelClientMock.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenLabelClientIsNull()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new GitLabClient(issueClientMock.Object, mergeRequestClientMock.Object, milestonesClientMock.Object, null!));
        }
    }
}

